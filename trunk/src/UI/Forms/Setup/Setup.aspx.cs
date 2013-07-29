namespace THS.UMS.UI.Forms.Setup
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Reflection;
    using System.Web.Configuration;

    using THS.UMS.AO;
    using THS.UMS.UI.Controls.Helpers;
    using THS.UMS.UI.Utilities;

    public partial class Setup : System.Web.UI.Page
    {
        protected bool IsDatabaseVerified { get; set; }
        protected bool IsDirectoryVerified { get; set; }
        protected bool IsUserSecVerified { get; set; }
        protected string VerifiedUsername { get; set; }
        protected string VerifiedServer { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (!IsPostBack)
            {
                LoadInitialData();
                RefreshData();
            }
        }

        protected void rblDbWinSecurity_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDbUserMode();
        }

        protected void btnVerifyReqs_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Run initial verification
            RefreshData();

            // Double check verifications
            try
            {
                if (!IsDatabaseVerified)
                    throw new ApplicationException("Database is not verified");

                if (!IsDirectoryVerified)
                    throw new ApplicationException("Directory is not verified");

                if (!IsUserSecVerified)
                    throw new ApplicationException("User Security is not verified");
            }
            catch (ApplicationException ex)
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! " + ex.Message;
                omResult.Show();
            }

            var retVal = true;

            // Save Application Settings
            if (!AppSettings.SetValue("AppTitle", txtAppTitle.Text)) retVal = false;
            if (!AppSettings.SetValue("AppUrl", txtAppUrl.Text)) retVal = false;

            if (!retVal)
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not save all needed changes.";
                omResult.Show();
                return;
            }

            try
            {
                // Secure setup folder
                var sc = new Config("~/Forms/Setup/");
                var auth = sc.GetAuthorizationSettings();
                var rule = new AuthorizationRule(AuthorizationRuleAction.Deny);
                rule.Users.Add("*");
                auth.Rules.Add(rule);
                sc.SaveConfiguration();

                // Turn off installer and reload application
                var c = new Config();
                c.SetApplicationSetting("RunInstaller", "false");
                c.SaveConfiguration();

                // Redirect
                Response.Redirect("~/");
            }
            catch (Exception)
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not save configuration changes.";
                omResult.Show();
            }
        }

        private void RefreshData()
        {
            VerifyDatabase();
            if (IsDatabaseVerified)
                VerifyDirectory();
            if (IsDirectoryVerified)
                VerifyUserSec();
            SetPanelVisibility();
            SetVerifyStatus();
        }

        private void SetPanelVisibility()
        {
            SetDbUserMode();
            pnlDirectory.Visible = IsDatabaseVerified;
            pnlUser.Visible = IsDirectoryVerified;

            pnlDatabase.Enabled = !IsDatabaseVerified;
            pnlDirectory.Enabled = !IsDirectoryVerified;
            pnlUser.Enabled = !IsUserSecVerified;

            if (IsDatabaseVerified && IsDirectoryVerified && IsUserSecVerified)
            {
                btnVerifyReqs.Visible = false;
                btnSubmit.Visible = true;
            }
            else
            {
                btnVerifyReqs.Visible = true;
                btnSubmit.Visible = false;
            }
        }

        private void SetVerifyStatus()
        {
            if (IsDatabaseVerified)
            {
                lblIsDatabaseVerified.Text = "YES";
                lblIsDatabaseVerified.ForeColor = Color.Green;
            }
            else
            {
                lblIsDatabaseVerified.Text = "NO";
                lblIsDatabaseVerified.ForeColor = Color.Red;
            }

            if (IsDirectoryVerified)
            {
                lblIsDirectoryVerified.Text = "YES" + " - " + VerifiedServer;
                lblIsDirectoryVerified.ForeColor = Color.Green;
            }
            else
            {
                lblIsDirectoryVerified.Text = "NO";
                lblIsDirectoryVerified.ForeColor = Color.Red;
            }

            if (IsUserSecVerified)
            {
                lblIsUserSecVerified.Text = "YES" + " - " + VerifiedUsername;
                lblIsUserSecVerified.ForeColor = Color.Green;
            }
            else
            {
                lblIsUserSecVerified.Text = "NO";
                lblIsUserSecVerified.ForeColor = Color.Red;
            }
        }

        private void SetDbUserMode()
        {
            if (!String.IsNullOrWhiteSpace(rblDbWinSecurity.SelectedValue))
                pnlDbSqlAuth.Visible = !Convert.ToBoolean(rblDbWinSecurity.SelectedValue);
        }

        private void VerifyUserSec()
        {
            string verifiedUsername;
            if (new AO.Setup().DoesUserExist(out verifiedUsername))
            {
                IsUserSecVerified = true;

                if (IsUserSecVerified)
                {
                    VerifiedUsername = verifiedUsername;
                    txtUpnUser.Text = verifiedUsername;
                    return;
                }
            }

            // Add User
            IsUserSecVerified = new AO.Setup().AddAdminUser(txtUpnUser.Text);
            if (IsUserSecVerified)
            {
                VerifiedUsername = txtUpnUser.Text;
            }
        }

        private void VerifyDatabase()
        {
            if (String.IsNullOrWhiteSpace(txtDbServer.Text)) return;
            if (String.IsNullOrWhiteSpace(txtDbCatalog.Text)) return;

            var c = new Config();
            var s = new SqlConnectionStringBuilder {DataSource = txtDbServer.Text, InitialCatalog = txtDbCatalog.Text};

            if (Convert.ToBoolean(rblDbWinSecurity.SelectedValue))
                s.IntegratedSecurity = true;
            else
            {
                s.UserID = txtDbUsername.Text;
                s.Password = txtDbPassword.Text;
            }
            s.MultipleActiveResultSets = true;

            // Test new connection
            if (!new AO.Setup().VerifyConnectionString(s.ConnectionString)) return;

            // Connection worked
            IsDatabaseVerified = true;
            
            if (!IsDatabaseVerified) return;

            // Save the connection
            c.SetDatabaseSettings(s.ConnectionString);

            // Load minor settings
            txtAppUrl.Text = "http://" + Request.Url.Host;
            txtAppTitle.Text = new AO.Setup().GetAppTitle();
            pnlOther.Visible = true;
        }

        private void VerifyDirectory()
        {
            string server;
            if (!new AO.Setup().VerifyDirectoryAccess(txtAdDomain.Text, txtAdUsername.Text, txtAdPassword.Text, out server))
                return;

            IsDirectoryVerified = true;
            VerifiedServer = server;

            if (!IsDirectoryVerified) return;

            // Save Directory Settings
            AppSettings.SetValue("AdPath", "LDAP://" + txtAdDomain.Text);
            AppSettings.SetValue("AdUser", txtAdUsername.Text);
            AppSettings.SetValue("AdUserPass", txtAdPassword.Text);
        }

        private void LoadInitialData()
        {
            // Try to load the existing connection string
            var c = new Config();
            var db = new SqlConnectionStringBuilder(c.GetDatabaseSettings().ProviderConnectionString);
            if (!String.IsNullOrWhiteSpace(db.DataSource))
            {
                // Test existing connection
                if (new AO.Setup().VerifyConnectionString(c.GetDatabaseSettings().ProviderConnectionString))
                {
                    IsDatabaseVerified = true;

                    // Set values so user can see them
                    txtDbServer.Text = db.DataSource;
                    txtDbCatalog.Text = db.InitialCatalog;
                    if (!db.IntegratedSecurity)
                    {
                        rblDbWinSecurity.SelectedValue = "False";
                        txtDbUsername.Text = db.UserID;
                        txtDbPassword.Text = db.Password;
                    }
                    else
                    {
                        rblDbWinSecurity.SelectedValue = "True";
                    }
                    pnlDbSqlAuth.Visible = Convert.ToBoolean(rblDbWinSecurity.SelectedValue);
                }
            }

            // Directory Settings
            if (!IsDatabaseVerified) return;
            var ad = new AO.Setup().GetAdSettings();
            txtAdDomain.Text = ad["AdPath"];
            txtAdUsername.Text = ad["AdUser"];
            txtAdPassword.Text = ad["AdUserPass"];
        }
    }
}
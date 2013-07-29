using System;
using System.IO;
using System.Web.UI.WebControls;
using PPI.UMS.BLL;
using PPI.UMS.BLL.Common;

namespace PPI.UMS.Web.Forms.Setup
{
    public partial class Wizard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Load the license
                try
                {
                    string file = Server.MapPath("~/License.txt");
                    StreamReader objReader = File.OpenText(file);
                    this.txtLicense.Text = objReader.ReadToEnd();
                    objReader.Close();
                }
                catch
                {
                    throw new Exception(Resources.Setup.Setup_Error_License);
                }

                //Get the current user identity to pre-populate fields
                if (!String.IsNullOrWhiteSpace(User.Identity.Name))
                    this.txtAddUserRoles.Text = User.Identity.Name;
            }
        }

        protected void Wizard1_ActiveStepChanged(object sender, EventArgs e)
        {
            //Verify AD Connection Details
            if (this.Wizard1.ActiveStep == this.wzdDatabase)
            {
                //User must have gone to the next wizard step so validate and return them if invalid
                string server;

                if (!String.IsNullOrWhiteSpace(this.txtADPassword.Text))
                    this.lblPassword.Text = this.txtADPassword.Text;

                if (!this.rbDomainConnect.Checked)
                {
                    Installer inst = new Installer();
                    if (!inst.VerifyDomainCredentials(this.txtADFQDN.Text, this.txtADUsername.Text, this.txtADPassword.Text, out server))
                    {
                        //The settings were invalid!
                        this.dlgADMessage.Message = Resources.Setup.Setup_Error_Domain_Message;
                        this.dlgADMessage.Mode = Web.Controls.Dialog.DialogMode.Critical;
                        this.dlgADMessage.Title = Resources.Setup.Setup_Error_Domain_Title;
                        this.dlgADMessage.Show();
                        this.Wizard1.ActiveStepIndex -= 1;
                    }
                    else
                    {
                        this.rbDomainConnect.Checked = true;
                        this.lblDomainController.Text = server;
                    }
                }
            }

            //Verify SQL Connection
            if (this.Wizard1.ActiveStep == this.wzdPortal)
            {
                if (!String.IsNullOrWhiteSpace(this.txtDbSaPass.Text))
                    this.lblDbPassword.Text = this.txtDbSaPass.Text;

                if (!this.rbDatabaseConnect.Checked)
                {
                    if (this.cbEnableDbSetup.Checked)
                    {
                        Installer inst = new Installer();
                        bool user = inst.VerifyUserExists(this.txtADFQDN.Text, this.txtADUsername.Text, this.lblPassword.Text, this.txtAddUserRoles.Text);
                        bool database = inst.VerifyDatabaseServer(this.txtDbServer.Text, this.txtDbSaPass.Text);

                        if (!user || !database)
                        {
                            if (!user)
                            {
                                //Username is bad
                                //The settings were invalid!
                                this.dlgDatabase.Message = Resources.Setup.Setup_Error_AdUser_Message;
                                this.dlgDatabase.Mode = Web.Controls.Dialog.DialogMode.Critical;
                                this.dlgDatabase.Title = Resources.Setup.Setup_Error_AdUser_Title;
                                this.dlgDatabase.Show();
                                this.Wizard1.ActiveStepIndex -= 1;
                            }
                            else
                            {
                                //The settings were invalid!
                                this.dlgDatabase.Message = Resources.Setup.Setup_Error_Database_Message;
                                this.dlgDatabase.Mode = Web.Controls.Dialog.DialogMode.Critical;
                                this.dlgDatabase.Title = Resources.Setup.Setup_Error_Database_Title;
                                this.dlgDatabase.Show();
                                this.Wizard1.ActiveStepIndex -= 1;
                            }
                        }
                        else
                        {
                            this.rbDatabaseConnect.Checked = true;
                        }
                    }
                }
            }

            //Show Summary
            if (this.Wizard1.ActiveStep == this.wzdSummary)
            {
                //Show Domain Info
                this.lblDomain.Text = string.Format(Resources.Setup.Setup_Summary_Domain, this.txtADFQDN.Text);
                this.lblUsername.Text = string.Format(Resources.Setup.Setup_Summary_Username, this.txtADUsername.Text);
                this.lblDomainController.Text = string.Format(Resources.Setup.Setup_Summary_DomainController, this.lblDomainController.Text);

                //Show DB Info
                if (this.cbEnableDbSetup.Checked)
                {
                    string dbCatalog;
                    string dbUser;
                    string dbPass;

                    Installer inst = new Installer();
                    inst.GenerateDatabaseInfo(this.txtADFQDN.Text, out dbCatalog, out dbUser, out dbPass);
                    this.lblDbServer.Text = string.Format(Resources.Setup.Setup_Summary_DbServer, this.txtDbServer.Text);
                    this.lblDbCatalog.Text = string.Format(Resources.Setup.Setup_Summary_DbCatalog, dbCatalog);
                    this.lblDbUser.Text = string.Format(Resources.Setup.Setup_Summary_DbUser, dbUser);
                }
                else
                {
                    this.lblDbServer.Text = Resources.Setup.Setup_Summary_DbNotEnabled;
                }

                //Show settings the user picked
                this.lblSettings.Text = string.Empty;
                foreach (ListItem item in this.CheckBoxList1.Items)
                {
                    if (item.Selected == true)
                        this.lblSettings.Text += "- " + item.Text + "<br />";
                }
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            Installer inst = new Installer();

            bool dbConfigured = false;
            bool appConfigured = false;

            //Configure the database
            if (this.cbEnableDbSetup.Checked)
            {
                dbConfigured = inst.InstallDatabase(this.txtDbServer.Text, this.lblDbPassword.Text, this.txtADFQDN.Text, this.txtAddUserRoles.Text);
            }

            //Install the application
            if (cbEnableDbSetup.Checked && dbConfigured)
                appConfigured = inst.InstallApplication(this.txtADFQDN.Text, this.txtADUsername.Text, this.lblPassword.Text, this.CheckBoxList1.Items);

            //Take app offline if db is not ready
            if ((!dbConfigured && cbEnableDbSetup.Checked) || !appConfigured)
                UiHelper.TakeAppOffline();

            //Reload the app
            Response.Redirect(this.Wizard1.FinishDestinationPageUrl);
        }

        protected void cbEnableDbSetup_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbEnableDbSetup.Checked)
            {
                this.pnlDbDetails.Visible = true;
            }
            else
            {
                this.pnlDbDetails.Visible = false;
            }
        }
    }
}
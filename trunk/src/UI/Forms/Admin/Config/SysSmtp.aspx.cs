namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;
    using System.Configuration;

    using THS.UMS.UI.Controls.Helpers;

    public partial class SysSmtp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindCurrentConfiguration();
        }

        private void ShowHideCredentials()
        {
            switch (rblAuthMode.SelectedValue)
            {
                case "BA":
                    UpdatePanel1.Visible = true;
                    break;
                default:
                    UpdatePanel1.Visible = false;
                    break;
            }
        }

        private void BindCurrentConfiguration()
        {
            try
            {
                // Get Configuration
                var c = new Utilities.Config(ConfigurationManager.AppSettings["ServiceConfigFile"]);
                var m = c.GetMailSettings();

                // Assign current values

                txtServer.Text = m.Smtp.Network.Host;
                txtPort.Text = m.Smtp.Network.Port.ToString();
                txtFrom.Text = m.Smtp.From;
                cbSsl.Checked = m.Smtp.Network.EnableSsl;

                if (m.Smtp.Network.DefaultCredentials)
                {
                    //NTLM
                    rblAuthMode.SelectedValue = "WI";
                }
                else if (String.IsNullOrWhiteSpace(m.Smtp.Network.UserName) && String.IsNullOrWhiteSpace(m.Smtp.Network.Password))
                {
                    //None
                    rblAuthMode.SelectedValue = "NA";
                }
                else
                {
                    //Basic
                    rblAuthMode.SelectedValue = "BA";
                    txtUsername.Text = m.Smtp.Network.UserName;
                }

                ShowHideCredentials();
            }
            catch (NullReferenceException)
            {
                // Config was not loaded or found
                pnlSettings.Visible = false;
                lblConfError.Visible = true;
            }
            catch (ArgumentException)
            {
                pnlSettings.Visible = false;
                lblConfError.Visible = true;
            }
        }

        protected void rblAuthMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowHideCredentials();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get current configuration
            var c = new Utilities.Config(ConfigurationManager.AppSettings["ServiceConfigFile"]);

            // Package the configuration settings
            var m = c.GetMailSettings();
            m.Smtp.Network.Host = txtServer.Text;
            m.Smtp.Network.Port = Int32.Parse(txtPort.Text);
            m.Smtp.From = txtFrom.Text;
            m.Smtp.Network.EnableSsl = cbSsl.Checked;

            switch (rblAuthMode.SelectedValue)
            {
                case "WI":
                    m.Smtp.Network.DefaultCredentials = true;
                    m.Smtp.Network.UserName = "";
                    m.Smtp.Network.Password = "";
                    break;
                case "NA":
                    m.Smtp.Network.DefaultCredentials = false;
                    m.Smtp.Network.UserName = "";
                    m.Smtp.Network.Password = "";
                    break;
                case "BA":
                    m.Smtp.Network.DefaultCredentials = false;
                    m.Smtp.Network.UserName = txtUsername.Text;
                    m.Smtp.Network.Password = txtPassword.Text;
                    break;
            }

            // Save changes
            if (c.SaveMailSettings(m, txtTest.Text))
            {
                omResult.Mode = OutputMessage.MessageMode.Success;
                omResult.Message = "Success! Saved Mail Settings";
                omResult.Show();
            }
            else
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could Not Save Mail Settings";
                omResult.Show();
            }
        }
    }
}
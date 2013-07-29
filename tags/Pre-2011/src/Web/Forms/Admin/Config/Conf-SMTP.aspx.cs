using System;
using System.Configuration;
using System.Net.Configuration;
using System.Web.Configuration;
using PPI.UMS.BLL;
using PPI.UMS.BLL.Common;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_SMTP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Bind the form
                BindForm();

                //Set the cred pane display value
                HideOrShowCredPane();
            }
        }

        private void BindForm()
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            MailSettingsSectionGroup mailer = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            this.txtServer.Text = mailer.Smtp.Network.Host;
            this.txtPort.Text = mailer.Smtp.Network.Port.ToString();
            this.txtFrom.Text = mailer.Smtp.From;
            this.cbSSL.Checked = mailer.Smtp.Network.EnableSsl;

            if (mailer.Smtp.Network.DefaultCredentials)
            {
                //NTLM
                this.rblAuthMode.SelectedValue = "WIN";
            }
            else if (String.IsNullOrWhiteSpace(mailer.Smtp.Network.UserName) && String.IsNullOrWhiteSpace(mailer.Smtp.Network.Password))
            {
                //None
                this.rblAuthMode.SelectedValue = "NA";
            }
            else
            {
                //Basic
                this.rblAuthMode.SelectedValue = "CRED";
                this.txtUsername.Text = mailer.Smtp.Network.UserName;
            }
        }

        protected void rblAuthMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideOrShowCredPane();
        }

        private void HideOrShowCredPane()
        {
            if (this.rblAuthMode.SelectedValue == "NA")
            {
                this.pnlCRED.Visible = false;
            }
            else if (this.rblAuthMode.SelectedValue == "CRED")
            {
                this.pnlCRED.Visible = true;
            }
            else if (this.rblAuthMode.SelectedValue == "WIN")
            {
                this.pnlCRED.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                MailSettingsSectionGroup mailer = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                //Test the connection
                UiHelper.SendTestEmail(this.txtServer.Text, Convert.ToInt32(this.txtPort.Text), this.cbSSL.Checked, this.txtFrom.Text, this.rblAuthMode.SelectedValue, this.txtUsername.Text, this.txtPass.Text, this.txtTestEmail.Text);

                //Ensure SMTP Section is encrypted
                UiHelper.ProtectSection(mailer.SectionGroupName + "/smtp", "DataProtectionConfigurationProvider");

                //Save the Info
                mailer.Smtp.Network.Host = this.txtServer.Text;
                mailer.Smtp.Network.Port = Convert.ToInt32(this.txtPort.Text);
                mailer.Smtp.From = this.txtFrom.Text;
                mailer.Smtp.Network.EnableSsl = this.cbSSL.Checked;

                if (this.rblAuthMode.SelectedValue == "WIN")
                {
                    //NTLM
                    mailer.Smtp.Network.UserName = "";
                    mailer.Smtp.Network.Password = "";
                    mailer.Smtp.Network.DefaultCredentials = true;
                }
                else if (this.rblAuthMode.SelectedValue == "NA")
                {
                    //None
                    mailer.Smtp.Network.UserName = "";
                    mailer.Smtp.Network.Password = "";
                    mailer.Smtp.Network.DefaultCredentials = false;
                }
                else
                {
                    //Basic
                    mailer.Smtp.Network.UserName = this.txtUsername.Text;
                    mailer.Smtp.Network.Password = this.txtPass.Text;
                    mailer.Smtp.Network.DefaultCredentials = false;
                }

                config.Save();

                //Log to Timelines
                Messages msg = new Messages();
                msg.AddMessage(Resources.Messages.Admin_SMTP_Saved_Title,String.Format(Resources.Messages.Admin_SMTP_Saved_Message, this.txtServer.Text),"SMTP",true);

                //Show success
                this.Dialog1.Message = Resources.Admin.Config_SMTP_Success_Description;
                this.Dialog1.Mode = Web.Controls.Dialog.DialogMode.Success;
                this.Dialog1.Title = Resources.Admin.Config_SMTP_Success_Title;
                this.Dialog1.Show();
            }
            catch
            {
                //Log to Timelines
                Messages msg = new Messages();
                msg.AddMessage(Resources.Messages.Admin_SMTP_Fail_Title, Resources.Messages.Admin_SMTP_Fail_Message, "SMTP", true);

                this.Dialog1.Message = Resources.Admin.Config_SMTP_Failure_Description;
                this.Dialog1.Mode = Web.Controls.Dialog.DialogMode.Critical;
                this.Dialog1.Title = Resources.Admin.Config_SMTP_Failure_Title;
                this.Dialog1.Show();
            }
        }
    }
}
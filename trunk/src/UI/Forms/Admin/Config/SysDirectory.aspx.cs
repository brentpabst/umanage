namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;

    using THS.UMS.UI.Controls.Helpers;

    public partial class SysDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GetDirectoryInfo();
        }

        private void GetDirectoryInfo()
        {
            var s = new AO.Setup().GetAdSettings();


            txtDirectory.Text = s["AdPath"];
            txtUsername.Text = s["AdUser"];
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var c = new AppSettings();

            // Save changes
            var server = "";
            if (new AO.Setup().VerifyDirectoryAccess(txtDirectory.Text, txtUsername.Text, txtPassword.Text, out server))
            {
                try
                {
                    AO.AppSettings.SetValue("AdPath", "LDAP://" + txtDirectory.Text);
                    AO.AppSettings.SetValue("AdUser", txtUsername.Text);
                    AO.AppSettings.SetValue("AdUserPass", txtPassword.Text);

                    omResult.Mode = OutputMessage.MessageMode.Success;
                    omResult.Message = "Success! Changed Directory Settings.";
                    omResult.Show();
                }
                catch (Exception)
                {
                    omResult.Mode = OutputMessage.MessageMode.Failure;
                    omResult.Message = "Failed! Could not save changes.";
                    omResult.Show();
                }
            }
            else
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not verify directory connection.";
                omResult.Show();
            }
        }
    }
}
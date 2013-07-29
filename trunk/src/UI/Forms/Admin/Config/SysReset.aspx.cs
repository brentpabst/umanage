namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;

    using THS.UMS.UI.Controls.Helpers;

    public partial class SysReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Clear App Settings
            var retVal = true;
            if (!AO.AppSettings.SetValue("AppTitle", "Welcome to uManage")) retVal = false;
            if (!AO.AppSettings.SetValue("AppUrl", "http://")) retVal = false;

            // Save Directory Settings
            if (!AO.AppSettings.SetValue("AdPath", "")) retVal = false;
            if (!AO.AppSettings.SetValue("AdUser", "")) retVal = false;
            if (!AO.AppSettings.SetValue("AdUserPass", "")) retVal = false;

            if (!retVal)
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not save all needed changes.";
                omResult.Show();
                return;
            }

            try
            {
                // Clear Database Settings
                var c = new Utilities.Config();
                c.SetDatabaseSettings("");

                // Remove authorization on setup wizard
                var sc = new Utilities.Config("~/Forms/Setup/");
                var auth = sc.GetAuthorizationSettings();
                auth.Rules.RemoveAt(0);
                sc.SaveConfiguration();

                // Turn on Setup Wizard
                c.SetApplicationSetting("RunInstaller", "true");
                c.SaveConfiguration();
            }
            catch (Exception)
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not save all configuration changes.";
                omResult.Show();
            }

            // Reload Application
            Response.Redirect("~/");
        }
    }
}
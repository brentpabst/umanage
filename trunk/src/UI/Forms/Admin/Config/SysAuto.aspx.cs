namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;
    using System.Configuration;

    using THS.UMS.UI.Controls.Helpers;

    public partial class SysAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPath.Text = ConfigurationManager.AppSettings["ServiceConfigFile"];
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPath.Text)) return;

            try
            {
                var c = new Utilities.Config();
                c.SetApplicationSetting("ServiceConfigFile", txtPath.Text);
                c.SaveConfiguration();

                omResult.Mode = OutputMessage.MessageMode.Success;
                omResult.Message = "Success! Changed the configuration file path.";
                omResult.Show();
            }
            catch (Exception)
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not change the path.";
                omResult.Show();
            }
        }
    }
}
namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;

    using THS.UMS.UI.Controls.Helpers;
    using THS.UMS.UI.Utilities;

    public partial class SysOffline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check Verification
            if (cbVerify.Checked)
            {
                // Take Offline
                Startup.TakeAppOffline();
                Response.Redirect("~/");
            }

            // Error, not verified
            omResult.Mode = OutputMessage.MessageMode.Failure;
            omResult.Message = "Failed! You did not verify your decision!";
            omResult.Show();
        }
    }
}
namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;
    using System.Configuration;
    using System.Web.UI.WebControls;

    using THS.UMS.UI.Controls.Helpers;

    public partial class AppSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Populate the form
                cblSettings.Items.FindByValue("AllowUserPasswordChanges").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPasswordChanges"]);
                cblSettings.Items.FindByValue("AllowUserAttibChanges").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserAttibChanges"]);
                cblSettings.Items.FindByValue("AllowUserNameChanges").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserNameChanges"]);
                cblSettings.Items.FindByValue("AllowUserEmailChanges").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserEmailChanges"]);
                cblSettings.Items.FindByValue("AllowUserLocationChanges").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserLocationChanges"]);
                cblSettings.Items.FindByValue("AllowUserPhoneChanges").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPhoneChanges"]);
                cblSettings.Items.FindByValue("AllowUserPhotoChanges").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPhotoChanges"]);
                cblSettings.Items.FindByValue("DisplayUserLocationSection").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserLocationSection"]);
                cblSettings.Items.FindByValue("DisplayUserPhoneSection").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserPhoneSection"]);
                cblSettings.Items.FindByValue("DisplayUserOrganizationSection").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserOrganizationSection"]);
                cblSettings.Items.FindByValue("DisplayUserPhotoSection").Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserPhotoSection"]);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var c = new Utilities.Config();
                foreach (ListItem i in cblSettings.Items)
                {
                    c.SetApplicationSetting(i.Value, i.Selected.ToString());
                }
                c.SaveConfiguration();

                omResult.Mode = OutputMessage.MessageMode.Success;
                omResult.Message = "Success! Saved portal settings.";
                omResult.Show();
            }
            catch (Exception)
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failure! Could not save portal settings.";
                omResult.Show();
            }
        }
    }
}
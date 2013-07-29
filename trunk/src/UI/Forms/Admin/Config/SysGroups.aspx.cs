namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;

    using THS.UMS.UI.Controls.Helpers;

    public partial class SysGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            var ignoreList = AO.AppSettings.GetValue("GroupsToIgnore");
            txtGroups.Text = ignoreList;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AO.AppSettings.SetValue("GroupsToIgnore", txtGroups.Text)) throw new ApplicationException("CouldNotSave");
                omResult.Mode = OutputMessage.MessageMode.Success;
                omResult.Message = "Success! Saved Groups to Ignore Settings.";
                omResult.Show();
            }
            catch (Exception)
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not save changes.";
                omResult.Show();
            }

        }
    }
}
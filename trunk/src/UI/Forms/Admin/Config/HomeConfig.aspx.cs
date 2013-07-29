using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace THS.UMS.UI.Forms.Admin.Config
{
    using THS.UMS.UI.Controls.Helpers;

    public partial class HomeConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindForm();
        }

        private void BindForm()
        {
            cbEnabled.Checked = Convert.ToBoolean(AO.AppSettings.GetValue("HomePageEnabled"));
            cbOverride.Checked = Convert.ToBoolean(AO.AppSettings.GetValue("HomePageOverride"));
            txtOrgName.Text = AO.AppSettings.GetValue("OrgName");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                AO.AppSettings.SetValue("HomePageEnabled", cbEnabled.Checked.ToString());
                AO.AppSettings.SetValue("HomePageOverride", cbOverride.Checked.ToString());
                AO.AppSettings.SetValue("OrgName", txtOrgName.Text);

                omResult.Mode = OutputMessage.MessageMode.Success;
                omResult.Message = "Success! Saved changes.";
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
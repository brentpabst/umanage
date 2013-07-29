namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;
    using System.Configuration;
    using System.Web.UI.WebControls;

    using THS.UMS.UI.Controls.Helpers;

    public partial class AppDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                cbOffice.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDepartmentList"]);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var c = new Utilities.Config();
                c.SetApplicationSetting("EnableDepartmentList", cbOffice.Checked.ToString());
                c.SaveConfiguration();

                omResult.Mode = OutputMessage.MessageMode.Success;
                omResult.Message = "Success! Changed the Department List mode.";
                omResult.Show();
            }
            catch (Exception)
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not change the Department List mode.";
                omResult.Show();
            }
        }

        protected void ObjectDataSource2_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void ObjectDataSource2_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectedIndex = -1;
        }
    }
}
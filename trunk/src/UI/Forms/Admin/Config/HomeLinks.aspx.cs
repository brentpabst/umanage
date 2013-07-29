namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;
    using System.Web.UI.WebControls;

    using THS.UMS.UI.Controls.Helpers;

    public partial class HomeLinks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) cbEnabled.Checked = Convert.ToBoolean(AO.AppSettings.GetValue("QuickLinksEnabled"));
        }

        protected void ObjectDataSource2_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void ObjectDataSource2_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectedIndex = -1;
        }

        protected void ObjectDataSource2_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectedIndex = -1;
        }

        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                GridView1.SelectedIndex = -1;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                AO.AppSettings.SetValue("QuickLinksEnabled", cbEnabled.Checked.ToString());

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
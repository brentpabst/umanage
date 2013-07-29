namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;
    using System.Web.UI.WebControls;

    public partial class AppLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource2_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectedIndex = -1;
        }

        protected void ObjectDataSource2_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            GridView1.DataBind();
        }
    }
}
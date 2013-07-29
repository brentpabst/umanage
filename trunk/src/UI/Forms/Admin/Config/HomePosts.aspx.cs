using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace THS.UMS.UI.Forms.Admin.Config
{
    public partial class HomePosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}
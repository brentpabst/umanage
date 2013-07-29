using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PPI.UMS.Web.App_Master
{
    public partial class User : System.Web.UI.MasterPage
    {
        AD.User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteMap.CurrentNode != null)
                Page.Title = "uManage - " + SiteMap.CurrentNode.Title;
            else
                Page.Title = "uManage";

            user = new AD.User(HttpContext.Current.User.Identity.Name);
            Label userlabel = (Label)this.LoginView1.FindControl("lblUsername");
            if (userlabel != null)
                userlabel.Text = String.Format(Resources.User.Mast_UserName, user.DisplayName);
        }
    }
}
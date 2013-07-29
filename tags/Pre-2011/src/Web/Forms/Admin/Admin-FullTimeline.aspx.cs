using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPI.UMS.Web.Forms.Admin
{
    public partial class Admin_FullTimeline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string UserDisplayName()
        {
            AD.User user = new AD.User(Eval("CreatedBy").ToString());
            return user.DisplayName;
        }
    }
}
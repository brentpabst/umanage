using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

namespace PPI.UMS.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool LaunchWizard = false;

            try
            {
                LaunchWizard = Convert.ToBoolean(ConfigurationManager.AppSettings["LaunchSetupWizard"]);
            }
            catch { }

            //See if we launch the app or the setup wizard
            if (!LaunchWizard)
            {
                //Launch the app
                //Check which portal the user should go to
                if (Roles.IsUserInRole("Admin"))
                {
                    //Launch Admin Portal
                    Response.Redirect("~/Forms/Admin/Admin-Dash.aspx");
                }
                else
                {
                    //Launch user portal
                    Response.Redirect("~/Forms/Users/User-Info.aspx");
                }
            }
            else
            {
                //Launch the setup wizard
                Response.Redirect("~/Forms/Setup/Wizard.aspx");
            }
        }
    }
}
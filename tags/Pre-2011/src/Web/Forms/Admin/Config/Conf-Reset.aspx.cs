using System;
using PPI.UMS.BLL;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_Reset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Take it down
            Installer inst = new Installer();
            inst.Teardown();

            //Reload the app
            Response.Redirect("~/");
        }
    }
}
namespace THS.UMS.UI
{
    using System;

    using THS.UMS.UI.Utilities;

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(Startup.GetLoadLocation());
        }
    }
}
namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;
    using System.Reflection;

    public partial class SysSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
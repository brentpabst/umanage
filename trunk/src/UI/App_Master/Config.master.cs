namespace THS.UMS.UI.App_Master
{
    using System;
    using System.Web;

    public partial class Config : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string IsSelected(string url)
        {
            var node = SiteMap.CurrentNode;
            if (node != null && node.Url.Equals(url))
            {
                return "selected";
            }
            return "";
        }
    }
}
using System;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPI.UMS.BLL.Common;

namespace PPI.UMS.Web.App_Master
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        AD.User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = new AD.User(HttpContext.Current.User.Identity.Name);

            this.lblUsername.Text = String.Format(Resources.Admin.Mast_Username, user.DisplayName);
            this.lblDomainName.Text = UiHelper.GetCurrentDomainName();
            this.lblVersion.Text = String.Format(Resources.Admin.Foot_Version, Assembly.GetExecutingAssembly().GetName().Version.ToString());

            if (SiteMap.Providers["AdminSitemapProvider"].CurrentNode != null)
            {
                Page.Title = "uManage Admin - " + SiteMap.Providers["AdminSitemapProvider"].CurrentNode.Title;
                this.lblPageInfo.Text = SiteMap.Providers["AdminSitemapProvider"].CurrentNode.Description;
            }
            else
            {
                Page.Title = "uManage Admin";
            }
        }

        protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            //Ensure master tab is selected
            SiteMapNode node = SiteMap.Providers["AdminSitemapProvider"].CurrentNode;
            if (SiteMap.RootNode != null)
            {
                while ((node != null) && (node.ParentNode != null) && (!node.ParentNode.Equals(SiteMap.RootNode)) && (!node.Url.Equals(e.Item.NavigateUrl)))
                {
                    node = node.ParentNode;
                }
                if ((node != null) && (node.ParentNode != null) && node.Url.Equals(e.Item.NavigateUrl))
                {
                    e.Item.Selected = true;
                }
            }

        }
    }
}
namespace THS.UMS.UI.App_Master
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Security;

    using THS.UMS.AO;
    using THS.UMS.DTO;

    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptInclude(GetType(), "Ums.Ajax", ResolveClientUrl("~/Scripts/ums.ajax.js"));

            lblTitle.Text = AppSettings.GetValue("AppTitle");
            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (SiteMap.CurrentNode != null)
                Page.Title = "uManage - " + SiteMap.CurrentNode.Title;
            else
                Page.Title = "uManage";

            SetPortalMode();

            var emp = (EmployeeDTO)Session["CurrentEmp"];
            if (emp == null) return;

            lblName.Text = emp.DisplayName;
            lblOrg.Text = " | " + emp.Company;
        }

        private void SetPortalMode()
        {
            var node = SiteMap.CurrentNode;
            if (node == null) return;
            while ((node.ParentNode != null) && !String.IsNullOrWhiteSpace(node.ParentNode.Description))
            {
                node = node.ParentNode;
            }

            if (Roles.IsUserInRole("AdminPortal"))
            {
                if (node.Description == "user")
                {
                    hlPortalMode.NavigateUrl = "~/admin/dash";
                    hlPortalMode.Text = "View Admin Portal";
                }
                else
                {
                    hlPortalMode.NavigateUrl = "~/my/info";
                    hlPortalMode.Text = "View User Portal";
                }
            }

            if (Convert.ToBoolean(AppSettings.GetValue("HomePageEnabled"))) lHomePage.Text = "<a href=\"/home\">View Home Page</a> | ";
        }

        protected string IsSelected(string url)
        {
            var node = SiteMap.CurrentNode;
            if (node == null) return "";
            return node.Url.Equals(url) ? "selected" : "";
        }

        protected string IsRoot(string url)
        {
            var node = SiteMap.CurrentNode;
            if (node == null) return "";
            while ((node.ParentNode != null) && !String.IsNullOrWhiteSpace(node.ParentNode.Title))
            {
                node = node.ParentNode;
            }
            return node.Url.Equals(url) ? "selected" : "";
        }

        protected string IsParent(string url)
        {
            var node = SiteMap.CurrentNode;
            if (node == null) return "";
            if ((node.ParentNode != null) && !String.IsNullOrWhiteSpace(node.ParentNode.Title))
            {
                node = node.ParentNode;
            }
            return node.Url.Equals(url) ? "selected" : "";
        }
    }
}
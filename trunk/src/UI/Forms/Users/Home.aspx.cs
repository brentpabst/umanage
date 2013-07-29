namespace THS.UMS.UI.Forms.Users
{
    using System;
    using System.Linq;
    using System.Web.Security;

    using THS.UMS.AO;
    using System.Web;

    using THS.UMS.DTO;

    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindData();
        }

        private void BindData()
        {
            var nodes = SiteMap.Provider.FindSiteMapNode("~/my/info").ParentNode.ChildNodes;
            rptUManageLinks.DataSource = nodes;
            rptUManageLinks.DataBind();

            var orgName = AppSettings.GetValue("OrgName");
            Page.Title = "Welcome to " + orgName;
            lOrgName.Text = orgName;
            lOrgNameFoot.Text = orgName;

            pnlQuickLinks.Visible = Convert.ToBoolean(AppSettings.GetValue("QuickLinksEnabled"));

            UserBadge1.Employee = HttpContext.Current.Session["CurrentEmp"] as EmployeeDTO;

            var emp = (EmployeeDTO)Session["CurrentEmp"];
            if (emp != null)
            {
                // Check Password Expiration
                if (emp.PasswordExpDate <= DateTime.Now.AddDays(14))
                {
                    var span = emp.PasswordExpDate - DateTime.Now;
                    pnlAlert.Visible = true;
                    lAlert.Text = emp.FirstName + ", your password will expire in " + span.TotalDays.ToString("0")
                                  + " days. <a href=\"/my/password\">Change it now!</a>";
                }

                // Check Account Expiration
                if (emp.AccountExpDate <= DateTime.Now.AddDays(14))
                {
                    var span = emp.AccountExpDate - DateTime.Now;
                    pnlAlert.Visible = true;
                    lAlert.Text = emp.FirstName + ", your account will expire in " + span.TotalDays.ToString("0")
                                  + " days. Contact an Administrator!";
                }
            }
        }

        protected bool IsAdmin()
        {
            return Roles.IsUserInRole("AdminPortal");
        }
    }
}
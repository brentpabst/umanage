namespace THS.UMS.UI.Forms.Users
{
    using System;

    using THS.UMS.DTO;
    using THS.UMS.UI.Utilities;

    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDn.Text = User.Identity.Name;

            var emp = (EmployeeDTO)Session["CurrentEmp"];
            if (emp == null) return;

            lblUsername.Text = emp.UpnUsername;
            lblDn.Text = emp.DistinguishedName + " - " + User.Identity.Name;
            lblAccountLocked.Text = Formatting.FormatBoolean(emp.AccountLocked);
            lblAccountExp.Text = Formatting.FormatAccountExpiration(emp.AccountExpDate);
            lblPasswordExp.Text = Formatting.FormatPasswordExpiration(emp.PasswordExpDate);
        }
    }
}
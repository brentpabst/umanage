namespace THS.UMS.UI.Forms.Admin.User
{
    using System;
    using System.Linq;

    using THS.UMS.AO;
    using THS.UMS.UI.Utilities;

    public partial class UsrList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.SetFocus(txtSearch);
        }

        protected string FormatBoolean(bool b)
        {
            return Formatting.FormatBoolean(b);
        }

        protected string AccountExpires(DateTime d)
        {
            return Formatting.FormatAccountExpiration(d);
        }

        protected string PasswordExpires(DateTime d)
        {
            return Formatting.FormatPasswordExpiration(d);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var emp = new Employees();
            GridView1.DataSource = emp.SearchAndLoadEmployees(txtSearch.Text).OrderBy(s => s.SortName);
            GridView1.DataBind();
        }
    }
}
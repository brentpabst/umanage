namespace THS.UMS.UI.Forms.Admin.Groups
{
    using System;
    using System.Text.RegularExpressions;

    using THS.UMS.AO;

    public partial class GroupList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.SetFocus(txtSearch);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var grp = new GroupMembership();
            grdGroups.DataSource = grp.SearchAndLoadGroups(txtSearch.Text);
            grdGroups.DataBind();
        }

        protected void lnkShowAll_Click(object sender, EventArgs e)
        {
            var grp = new GroupMembership();
            grdGroups.DataSource = grp.ReturnAllGroups();
            grdGroups.DataBind();
        }

        protected string removeContainer(string groupName)
        {
            return Regex.Replace(groupName, "CN=", String.Empty);
        }

    }
}
namespace THS.UMS.UI.Forms.Admin.Groups
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using THS.UMS.AO;
    using THS.UMS.UI.Controls.Helpers;

    public partial class GroupDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                grpInfoBind();
        }

        protected void tabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            if (tabContainer1.ActiveTabIndex == 1)
            {
                //Only show the members when the Tab is active
                grpDataBind();
            }
        }

        protected void grdGroupMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveUser")
            {
                var user = Convert.ToString(e.CommandArgument);
                var group = Page.RouteData.Values["upn"].ToString();

                var g = new GroupMembership();
                if (g.RemoveUserFromGroup(user, group))
                {
                    ouMemberResult.Mode = OutputMessage.MessageMode.Success;
                    ouMemberResult.Message = "Success! It will take a few minutes to update the group.";
                    ouMemberResult.Show();
                    grpDataBind();
                }
                else
                {
                    ouMemberResult.Mode = OutputMessage.MessageMode.Failure;
                    ouMemberResult.Message = "Failed! Could not remove user.";
                    ouMemberResult.Show();
                }
            }
        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var ctrl = e.CommandSource as Control;
            if (e.CommandName == "AddUser")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                var user = Convert.ToString(e.CommandArgument);
                var group = Page.RouteData.Values["upn"].ToString();

                var grp = new GroupMembership();
                var isUserAdded = grp.AddUserToGroup(user, group);
                if (isUserAdded)
                {
                    ouMemberAdd.Mode = OutputMessage.MessageMode.Success;
                    ouMemberAdd.Message = "Success! It will take a few minutes to update the group.";
                    ouMemberAdd.Show();
                    grpDataBind();

                    if (ctrl != null)
                    {
                        var curRow = ctrl.Parent.NamingContainer as GridViewRow;
                        if (curRow != null)
                        {
                            var userButton = curRow.FindControl("btnAdd");
                            if (userButton != null)
                            {
                                userButton.Visible = false;
                            }
                        }
                    }
                }
                else
                {
                    ouMemberAdd.Mode = OutputMessage.MessageMode.Failure;
                    ouMemberAdd.Message = "Failed! Could not add user.";
                    ouMemberAdd.Show();
                }
            }
        }

        protected void grdManager_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var ctrl = e.CommandSource as Control;
            if (e.CommandName == "AddManager")
            {
                var user = Convert.ToString(e.CommandArgument);
                var group = Page.RouteData.Values["upn"].ToString();

                var grp = new GroupMembership();
                if (grp.UpdateGroupManager(user, group))
                {
                    ouManagerAdd.Mode = OutputMessage.MessageMode.Success;
                    ouManagerAdd.Message = "Success! It will take a few minutes to update the group.";
                    ouManagerAdd.Show();

                    if (ctrl != null)
                    {
                        var curRow = ctrl.Parent.NamingContainer as GridViewRow;
                        if (curRow != null)
                        {
                            var userButton = curRow.FindControl("btnAddManager");
                            if (userButton != null)
                            {
                                userButton.Visible = false;
                            }
                        }
                    }
                }
                else
                {
                    ouManagerAdd.Mode = OutputMessage.MessageMode.Failure;
                    ouManagerAdd.Message = "Failed! Could not set the manager.";
                    ouManagerAdd.Show();
                }
            }
        }

        protected void lnkUpdateDisc_Click(object sender, EventArgs e)
        {
            string group = Page.RouteData.Values["upn"].ToString();
            string Description = lDescription.Text;
            GroupMembership grp = new GroupMembership();
            grp.UpdateGroupDescription(group, Description);
            grpInfoBind();
        }

        private void grpInfoBind()
        {
            var grp = new GroupMembership().GetGroupByName(this.Page.RouteData.Values["upn"].ToString());

            if (!String.IsNullOrWhiteSpace(grp.ManagedBy))
            {
                var manager = new Employees().GetEmployeeByUsername(grp.ManagedBy);
                txtSearchManager.Text = manager.DisplayName;
            }
            this.lblSecurityGroup.Text = grp.isSecurityGroup ? "Security Group" : "Distribution Group";

            lblGroupName.Text = grp.Name;
            lDescription.Text = grp.Description;
        }

        private void grpDataBind()
        {
            grdGroupMembers.DataSource = "";
            grdGroupMembers.DataBind();

            var grpUsers = new Employees().GetGroupMembers(this.Page.RouteData.Values["upn"].ToString());

            grdGroupMembers.DataSource = grpUsers;
            grdGroupMembers.DataBind();
        }

        protected void lbSearchUser_Click(object sender, EventArgs e)
        {
            var emp = new Employees();
            gvUserResult.DataSource = emp.SearchAndLoadEmployees(txtUser.Text).OrderBy(s => s.UpnUsername);
            gvUserResult.DataBind();
        }

        protected void lbSearchForManager_Click(object sender, EventArgs e)
        {
            var emp = new Employees();
            gvManagerResults.DataSource = emp.SearchAndLoadEmployees(txtSearchManager.Text).OrderBy(s => s.UpnUsername);
            gvManagerResults.DataBind();
        }

    }
}
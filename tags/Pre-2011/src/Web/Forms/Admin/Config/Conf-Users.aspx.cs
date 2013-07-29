using System;
using System.Linq;
using System.Web.Security;
using PPI.UMS.AD;
using PPI.UMS.BLL;
using PPI.UMS.BLL.Common;
using PPI.UMS.DAL;
using System.Collections.Specialized;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Assign Domain Name to make things a little easier
                this.txtUsername.Text = UiHelper.GetCurrentDomainName() + "\\";

                BindDropDown();
            }
        }

        protected void BindDropDown()
        {
            this.DropDownList1.Items.Clear();
            using (uManageEntities context = new uManageEntities())
            {
                NameValueCollection list = new NameValueCollection();
                foreach (DAL.User user in context.Users.Distinct())
                {
                    list.Add(user.UserName, user.UserName);
                }
                this.DropDownList1.DataSource = list;
                this.DropDownList1.DataBind();
            }            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownList1.SelectedValue != "NA")
            {
                string username = this.DropDownList1.SelectedValue;

                this.cbAdmin.Checked = Roles.IsUserInRole(username, "Admin");
                this.cbSystem.Checked = Roles.IsUserInRole(username, "System");
            }
        }

        protected void btnUpdateSubmit_Click(object sender, EventArgs e)
        {
            //Update the user's roles
            if (this.DropDownList1.SelectedValue != "NA")
            {
                string username = this.DropDownList1.SelectedValue;

                if (this.cbAdmin.Checked)
                {
                    //See if user is already in the role
                    if (!Roles.IsUserInRole(username, "Admin"))
                    {
                        //Add to Admin
                        Roles.AddUserToRole(username, "Admin");
                    }
                }
                else
                {
                    //See if user is in the role
                    if (Roles.IsUserInRole(username, "Admin"))
                    {
                        //Remove from Admin
                        Roles.RemoveUserFromRole(username, "Admin");
                    }
                }

                if (this.cbSystem.Checked)
                {
                    //See if user is already in the role
                    if (!Roles.IsUserInRole(username, "System"))
                    {
                        //Add to Admin
                        Roles.AddUserToRole(username, "System");
                    }
                }
                else
                {
                    //See if user is in the role
                    if (Roles.IsUserInRole(username, "System"))
                    {
                        //Remove from Admin
                        Roles.RemoveUserFromRole(username, "System");
                    }
                }

                Messages msg = new Messages();
                msg.AddMessage(Resources.Messages.Admin_Users_Update_Title,String.Format(Resources.Messages.Admin_Users_Update_Message,username),"Users",true);

                this.Dialog1.Title = "Updates Saved!";
                this.Dialog1.Message = "User Role assignments were saved successfully for " + this.DropDownList1.SelectedValue;
                this.Dialog1.Mode = Web.Controls.Dialog.DialogMode.Success;
                this.Dialog1.Show();

                BindDropDown();
            }
        }

        protected void btnNewSubmit_Click(object sender, EventArgs e)
        {
            //Make sure the user entered is not already in a role
            string[] userRoles = Roles.GetRolesForUser(this.txtUsername.Text);

            if (!userRoles.Contains("Admin") && !userRoles.Contains("System"))
            {
                //Verify the user entered actually exists
                AD.User user = new AD.User(this.txtUsername.Text);
                if (user.Username != null)
                {
                    //Must have a user
                    //Make sure at least one role was selected
                    if (this.cbNewAdmin.Checked || this.cbNewSystem.Checked)
                    {
                        //Assign the selected roles
                        if (this.cbNewAdmin.Checked)
                        {
                            //Add Admin
                            Roles.AddUserToRole(this.txtUsername.Text, "Admin");
                        }

                        if (this.cbNewSystem.Checked)
                        {
                            //Add System
                            Roles.AddUserToRole(this.txtUsername.Text, "System");
                        }

                        Messages msg = new Messages();
                        msg.AddMessage(Resources.Messages.Admin_Users_Add_Title, String.Format(Resources.Messages.Admin_Users_Add_Message, this.txtUsername.Text), "Users", true);

                        //Success
                        this.Dialog2.Title = "Added User to Roles!";
                        this.Dialog2.Message = "Successfully added the user to the selected roles!";
                        this.Dialog2.Mode = Web.Controls.Dialog.DialogMode.Success;
                        this.Dialog2.Show();

                        BindDropDown();
                    }
                    else
                    {
                        //No roles were selected
                        this.Dialog2.Title = "Failed to Save Roles!";
                        this.Dialog2.Message = "You did not select any roles to assign to the user.  Please select at least one role and try again!";
                        this.Dialog2.Mode = Web.Controls.Dialog.DialogMode.Critical;
                        this.Dialog2.Show();
                    }
                }
                else
                {
                    //Could not locate the user specified
                    this.Dialog2.Title = "Failed to Save Roles!";
                    this.Dialog2.Message = "The user entered could not be found in the directory.  You must specify a user that has a valid account.";
                    this.Dialog2.Mode = Web.Controls.Dialog.DialogMode.Critical;
                    this.Dialog2.Show();
                }
            }
            else
            {
                //User has roles already
                this.Dialog2.Title = "Failed to Save Roles!";
                this.Dialog2.Message = "The user entered already has role assignments in the system.  Use the update user form instead.";
                this.Dialog2.Mode = Web.Controls.Dialog.DialogMode.Critical;
                this.Dialog2.Show();
            }
        }
    }
}
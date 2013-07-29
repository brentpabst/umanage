namespace THS.UMS.UI.Forms.Admin.User
{
    using System;

    using THS.UMS.AO;
    using THS.UMS.DTO;
    using THS.UMS.UI.Controls.Helpers;

    public partial class UsrDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            EmployeeDTO emp;
            var grps = new GroupMembership();

            if (String.IsNullOrWhiteSpace(Page.RouteData.Values["upn"].ToString()))
            {
                emp = (EmployeeDTO)Session["CurrentEmp"];
            }
            else
            {
                emp = new Employees().GetEmployeeByUsername(Page.RouteData.Values["upn"].ToString());
            }

            lblUserName.Text = emp.DisplayName;
            txtUserName.Text = emp.UpnUsername;

            chkUnlock.Checked = emp.AccountLocked;
            if (emp.AccountLocked) chkUnlock.Checked = true; else chkUnlock.Enabled = false;

            if (emp.AccountDisabled == false)
            {
                lnkDisable.Text = "Disable";
                lblDisableWarning.Visible = false;
                lblDisable.Visible = true;
            }
            else
            {
                lnkDisable.Text = "Enable";
                lblDisableWarning.Visible = true;
                lblDisable.Visible = false;
            }

            grdGroups.DataSource = grps.GetGroupsForUser(emp.UpnUsername);
            grdGroups.DataBind();
        }

        protected void lnkDisable_Click(Object sender, EventArgs e)
        {
            var emps = new Employees();

            var emp = new Employees().GetEmployeeByUsername(Page.RouteData.Values["upn"].ToString());
            if (emp.AccountDisabled)
            {
                //Account is disabled
                emps.EnableEmployee(emp.UpnUsername);
                lblDisableWarning.Visible = false;
                lblDisable.Visible = true;
                lnkDisable.Text = "Disable";
            }
            else
            {
                //Account is Enabled
                emps.DisableEmployee(emp.UpnUsername);
                lblDisableWarning.Visible = true;
                lblDisable.Visible = false;
                lnkDisable.Text = "Enable";
            }
        }

        protected void lnkUpdatePass_Click(object sender, EventArgs e)
        {
            // Trigger the password change and handle the results
            var emps = new Employees();
            if (emps.ChangeEmployeePassword(Page.RouteData.Values["upn"].ToString(), this.txtNewPass.Text, this.chkChangePass.Checked))
            {
                this.OutputMessage1.Message = "Success! Start using the new password.";
                this.OutputMessage1.Mode = OutputMessage.MessageMode.Success;
            }
            else
            {
                this.OutputMessage1.Message = "Failure! Could not save the password.";
                this.OutputMessage1.Mode = OutputMessage.MessageMode.Failure;
            }
            this.OutputMessage1.Show();
        }

        protected void chkUnlock_CheckedChanged(object sender, EventArgs e)
        {
            var emps = new Employees();
            emps.UnlockEmployee(Page.RouteData.Values["upn"].ToString());
        }
    }
}
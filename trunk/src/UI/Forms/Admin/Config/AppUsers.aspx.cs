namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using THS.UMS.AO;
    using THS.UMS.AO.Providers;
    using THS.UMS.UI.Controls.Helpers;

    public partial class AppUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) SetRowVisibility();
        }

        protected void ddlUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserList.SelectedValue != "")
            {
                var r = new Roles().GetUsersRoles(ddlUserList.SelectedValue);
                if (r.Length > 0)
                {
                    foreach (var i in r.Select(s => cblUserRoles.Items.FindByValue(s)).Where(i => i != null))
                    {
                        i.Selected = true;
                    }
                }
            }
        }

        protected void rblMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRowVisibility();
        }

        protected void lbSearchManager_Click(object sender, EventArgs e)
        {
            var emp = new Employees();
            gvResult.DataSource = emp.SearchForEmployees(txtManager.Text).OrderBy(s => s.Value);
            gvResult.DataBind();
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string u;
            if (rblMode.SelectedValue == "ADD")
            {
                u = (string)gvResult.SelectedValue;
                if (String.IsNullOrWhiteSpace(u))
                {
                    omResult.Mode = OutputMessage.MessageMode.Failure;
                    omResult.Message = "Failed! You must select a user.";
                    omResult.Show();
                    return;
                }
            }
            else
            {
                u = ddlUserList.SelectedValue;
            }

            var d = cblUserRoles.Items.Cast<ListItem>().ToDictionary(i => i.Value, i => i.Selected);
            if (new Roles().UpdateUserRoles(u,d))
            {
                omResult.Mode = OutputMessage.MessageMode.Success;
                omResult.Message = "Success! Updated Role Assignments.";
                omResult.Show();
            }
            else
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not update Role Assignments.";
                omResult.Show();
            }

            ResetForm();
        }

        private void ResetForm()
        {
            rblMode.Items.FindByValue("ADD").Selected = false;
            rblMode.Items.FindByValue("MOD").Selected = true;
            SetRowVisibility();
            ddlUserList.SelectedIndex = 0;
            foreach (ListItem i in cblUserRoles.Items)
            {
                i.Selected = false;
            }
        }

        private void SetRowVisibility()
        {
            switch (rblMode.SelectedValue)
            {
                case "ADD":
                    RowSelect.Visible = false;
                    RowAdd.Visible = true;
                    RowAddResult.Visible = true;
                    break;
                case "MOD":
                    RowSelect.Visible = true;
                    RowAdd.Visible = false;
                    RowAddResult.Visible = false;
                    break;
            }
        }
    }
}
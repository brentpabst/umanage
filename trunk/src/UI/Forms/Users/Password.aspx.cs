namespace THS.UMS.UI.Forms.Users
{
    using System;

    using THS.UMS.AO;
    using THS.UMS.DTO;
    using THS.UMS.UI.Controls.Helpers;
    using THS.UMS.UI.Utilities;

    public partial class Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var emp = (EmployeeDTO)Session["CurrentEmp"];
            if (emp != null)
            {
                this.lblTitle.Text = Formatting.FormatPasswordExpiration(emp.FirstName, emp.PasswordExpDate);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Trigger the password change and handle the results
            var emps = new Employees();
            if (emps.ChangeEmployeePassword(this.txtCurrentPass.Text, this.txtNewPass.Text, this.txtConfPass.Text))
            {
                Startup.LoadUserSessionInfo();
                this.OutputMessage1.Message = "Success! Start using your new password.";
                this.OutputMessage1.Mode = OutputMessage.MessageMode.Success;
            }
            else
            {
                this.OutputMessage1.Message = "Failure! Could not save your password.";
                this.OutputMessage1.Mode = OutputMessage.MessageMode.Failure;
            }

            this.OutputMessage1.Show();
        }
    }
}
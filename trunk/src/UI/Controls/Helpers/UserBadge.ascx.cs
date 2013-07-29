namespace THS.UMS.UI.Controls.Helpers
{
    using System;
    using System.Text;

    using THS.UMS.DTO;

    public partial class UserBadge : System.Web.UI.UserControl
    {
        public EmployeeDTO Employee { get; set; }
        public bool DisableHeaders { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Employee != null)
            {
                // Set Name
                lblName.Text = Employee.DisplayName;

                // Set Photo
                imgPhoto.Visible = true;
                imgPhoto.ImageUrl = "~/Controls/EmpPhoto.ashx?thumb=yes&u=" + Utilities.Encoder.EncodeString(Employee.UpnUsername);

                /* Populate the basic information
                     * Current Order:
                     * 1. Organization
                     * 2. Job Title
                     * 3. Business Phone
                     * 4. Mobile Phone
                     * 5. Fax
                     * 6. SIP/Skype
                     * 7. Home
                     * 8. E-Mail
                     */

                var s = new StringBuilder();

                if (!String.IsNullOrWhiteSpace(Employee.Company))
                    s.AppendLine(Employee.Company + "<br />");

                if (!String.IsNullOrWhiteSpace(Employee.JobTitle))
                    s.AppendLine(Employee.JobTitle + "<br />");

                if (!String.IsNullOrWhiteSpace(Employee.OfficePhone))
                    s.AppendLine(!DisableHeaders ? "Office:&nbsp;&nbsp;&nbsp;" + Employee.OfficePhone + "<br />" : Employee.OfficePhone + "<br />");

                if (!String.IsNullOrWhiteSpace(Employee.MobilePhone))
                    s.AppendLine(!DisableHeaders ? "Mobile:&nbsp;&nbsp;&nbsp;" + Employee.MobilePhone + "<br />" : Employee.MobilePhone + "<br />");

                if (!String.IsNullOrWhiteSpace(Employee.Fax))
                    s.AppendLine(!DisableHeaders ? "Fax:&nbsp;&nbsp;&nbsp;" + Employee.Fax + "<br />" : Employee.Fax + "<br />");

                if (!String.IsNullOrWhiteSpace(Employee.SipPhone))
                    s.AppendLine(!DisableHeaders ? "SIP:&nbsp;&nbsp;&nbsp;" + Employee.SipPhone + "<br />" : Employee.SipPhone + "<br />");

                if (!String.IsNullOrWhiteSpace(Employee.HomePhone))
                    s.AppendLine(!DisableHeaders ? "Home:&nbsp;&nbsp;&nbsp;" + Employee.HomePhone + "<br />" : Employee.HomePhone + "<br />");

                if (!String.IsNullOrWhiteSpace(Employee.Email))
                    s.AppendLine(!DisableHeaders ? "E-mail:&nbsp;&nbsp;&nbsp;" + "<a href=\"mailto:" + Employee.Email + "\">" +
                                 Employee.Email + "</a>" : "<a href=\"mailto:" + Employee.Email + "\">" +
                                 Employee.Email + "</a>");

                if (String.IsNullOrWhiteSpace(s.ToString()))
                    s.AppendLine("No Additional Information is Available.");

                lblBasicInfo.Text = s.ToString();
            }
            else
            {
                imgPhoto.Visible = false;
                lblName.Text = "Employee Not Available";
            }
        }
    }
}
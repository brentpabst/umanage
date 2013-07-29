namespace THS.UMS.UI.Forms.Admin.User
{
    using System;
    using System.Web.UI.WebControls;
    using System.Drawing;

    using THS.UMS.AO;

    public partial class UsrAuditDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (String.IsNullOrWhiteSpace(Page.RouteData.Values["id"].ToString())) return;

            var l = new AuditLog().GetAuditLog(Guid.Parse(Page.RouteData.Values["id"].ToString()));

            lblLogId.Text = l.LogId.ToString();
            lblLogDate.Text = l.LogDate.ToString();
            lblLogDateUtc.Text = l.LogDateUtc.ToString();
            lblSubmittedBy.Text = l.SubmittedBy;
            lblUpnUsername.Text = l.UpnUsername;
            txtFirstName.Text = l.FirstName;
            txtMiddleName.Text = l.MiddleName;
            txtLastName.Text = l.LastName;
            txtEmail.Text = l.Email;
            txtWebsite.Text = l.Website;
            txtJobTitle.Text = l.JobTitle;
            txtOffice.Text = l.OfficePhone;
            txtCompany.Text = l.Company;
            txtDepartment.Text = l.Department;
            txtEmployeeId.Text = l.EmployeeId;
            txtManager.Text = l.Manager;
            txtAddress1.Text = l.Address1;
            txtAddress2.Text = l.Address2;
            txtCity.Text = l.City;
            txtPostalCode.Text = l.PostalCode;
            txtState.Text = l.Province;
            txtCountry.Text = l.Country;
            txtHomePhone.Text = l.HomePhone;
            txtOfficePhone.Text = l.OfficePhone;
            txtPager.Text = l.Pager;
            txtMobilePhone.Text = l.MobilePhone;
            txtFax.Text = l.Fax;
            txtSip.Text = l.SipPhone;

            // Compare Old and New Values
            CompareValues(txtFirstName, lblFirstName, l.FirstName_Old);
            CompareValues(txtMiddleName, lblMiddleName, l.MiddleName_Old);
            CompareValues(txtLastName, lblLastName, l.LastName_Old);
            CompareValues(txtEmail, lblEmail, l.Email_Old);
            CompareValues(txtWebsite, lblWebsite, l.Website_Old);
            CompareValues(txtJobTitle, lblJobTitle, l.JobTitle_Old);
            CompareValues(txtOffice, lblOffice, l.Office_Old);
            CompareValues(txtCompany, lblCompany, l.Company_Old);
            CompareValues(txtDepartment, lblDepartment, l.Department_Old);
            CompareValues(txtEmployeeId, lblEmployeeId, l.EmployeeId_Old);
            CompareValues(txtManager, lblManager, l.Manager);
            CompareValues(txtAddress1, lblAddress1, l.Address1_Old);
            CompareValues(txtAddress2, lblAddress2, l.Address2_Old);
            CompareValues(txtCity, lblCity, l.City_Old);
            CompareValues(txtPostalCode, lblPostalCode, l.PostalCode_Old);
            CompareValues(txtState, lblState, l.Province_Old);
            CompareValues(txtCountry, lblCountry, l.Country_Old);
            CompareValues(txtHomePhone, lblHomePhone, l.HomePhone_Old);
            CompareValues(txtOfficePhone, lblOfficePhone, l.OfficePhone_Old);
            CompareValues(txtPager, lblPager, l.Pager_Old);
            CompareValues(txtMobilePhone, lblMobilePhone, l.MobilePhone_Old);
            CompareValues(txtFax, lblFax, l.Fax_Old);
            CompareValues(txtSip, lblSip, l.SipPhone_Old);
        }

        private static void CompareValues(TextBox txt, Label lbl, string oldValue)
        {
            if (txt.Text != (oldValue ?? ""))
            {
                // Different, show it
                if (oldValue == null) oldValue = "(Empty)";

                txt.ForeColor = Color.Red;
                lbl.Text = "<br />Old Value: " + oldValue;
            }
            else
            {
                lbl.Text = "";
                txt.ForeColor = Color.Black;
            }
        }
    }
}
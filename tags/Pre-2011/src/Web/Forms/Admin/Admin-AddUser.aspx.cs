using System;
using System.Configuration;
using PPI.UMS.BLL;
using PPI.UMS.DTO;

namespace PPI.UMS.Web.Forms.Admin
{
    public partial class Admin_AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool enabled = Boolean.Parse(ConfigurationManager.AppSettings["EnableNewUserCreation"]);

                if (enabled)
                {
                    this.pnlAdd.Visible = true;
                    this.pnlClosed.Visible = false;

                    // Load Data
                    LoadFormDefaults();
                }
                else
                {
                    this.pnlAdd.Visible = false;
                    this.pnlClosed.Visible = true;
                }
            }
        }

        private void LoadFormDefaults()
        {
            //Location Info
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeLocationList"]))
            {
                //Admin wants to use the dropdown list
                this.txtOffice.Visible = false;
                this.ddlOffice.Visible = true;

                //Bind the list
                this.ddlOffice.DataBind();
            }
            else
            {
                //Admin wants to use the textbox
                this.txtOffice.Visible = true;
                this.ddlOffice.Visible = false;
            }

            Employees emps = new Employees();
            this.ddlManager.DataSource = emps.GetAllEmployees();
            this.ddlManager.DataBind();

            this.txtAddress.Text = ConfigurationManager.AppSettings["CompanyAddress"];
            this.txtCity.Text = ConfigurationManager.AppSettings["CompanyCity"];
            this.txtState.Text = ConfigurationManager.AppSettings["CompanyState"];
            this.txtZip.Text = ConfigurationManager.AppSettings["CompanyPostal"];
            this.txtCountry.Text = ConfigurationManager.AppSettings["CompanyCountry"];
            this.txtOfficePhone.Text = ConfigurationManager.AppSettings["CompanyPhone"];
            this.txtCompany.Text = ConfigurationManager.AppSettings["CompanyName"];
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            emp.FirstName = this.txtFirstName.Text;
            emp.MiddleName = this.txtMiddleName.Text;
            emp.LastName = this.txtLastName.Text;
            emp.Email = this.txtEmail.Text;
            emp.Website = this.txtWebsite.Text;
            emp.Company = this.txtCompany.Text;
            emp.Department = this.txtDepartment.Text;
            emp.Manager = this.ddlManager.SelectedItem.Value;
            emp.EmployeeId = this.txtEmployeeId.Text;
            emp.JobTitle = this.txtTitle.Text;

            // Photo Logic
            if (this.fuPhoto.HasFile)
                emp.Picture = this.fuPhoto.FileBytes;

            // Office Logic
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeLocationList"]))
            {
                emp.Office = this.ddlOffice.SelectedItem.Text;
            }
            else
            {
                emp.Office = this.txtOffice.Text;
            }

            emp.Address1 = this.txtAddress.Text;
            emp.Address2 = this.txtPOBox.Text;
            emp.City = this.txtCity.Text;
            emp.State = this.txtState.Text;
            emp.PostalCode = this.txtZip.Text;
            emp.Country = this.txtCountry.Text;
            emp.PhoneOffice = this.txtOfficePhone.Text;
            emp.PhoneHome = this.txtHomePhone.Text;
            emp.PhoneMobile = this.txtMobile.Text;
            emp.PhonePager = this.txtPager.Text;
            emp.PhoneFax = this.txtFax.Text;
            emp.PhoneSip = this.txtIPPhone.Text;

            Employees emps = new Employees();
            Messages msg = new Messages();
            string retVal;
            if (emps.AddEmployee(emp, out retVal))
            {
                // Success
                this.dlgMessage.Title = Resources.Admin.Emp_Add_Submit_Success_Title;
                this.dlgMessage.Message = Resources.Admin.Emp_Add_Submit_Success_Msg;
                this.dlgMessage.Mode = Web.Controls.Dialog.DialogMode.Success;
                this.dlgMessage.Show();

                msg.AddMessage(Resources.Messages.Admin_User_Add_Success_Title, String.Format(Resources.Messages.Admin_User_Add_Success_Message, emp.FirstName + " " + emp.LastName), "Users", false);
            }
            else
            {
                // Failure
                this.dlgMessage.Title = Resources.Admin.Emp_Add_Submit_Fail_Title;
                this.dlgMessage.Message = String.Format(Resources.Admin.Emp_Add_Submit_Fail_Msg, retVal);
                this.dlgMessage.Mode = Web.Controls.Dialog.DialogMode.Critical;
                this.dlgMessage.Show();

                msg.AddMessage(Resources.Messages.Admin_User_Add_Fail_Title, String.Format(Resources.Messages.Admin_User_Add_Fail_Message, retVal), "Users", false);
            }

        }
    }
}
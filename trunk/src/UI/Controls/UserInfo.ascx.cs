namespace THS.UMS.UI.Controls
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Web.UI.WebControls;

    using THS.UMS.AO;
    using THS.UMS.DTO;
    using THS.UMS.UI.Controls.Helpers;
    using THS.UMS.UI.Utilities;

    public partial class UserInfo : System.Web.UI.UserControl
    {
        public enum Mode { Normal, ViewUser, AddUser }
        public Mode DisplayMode { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");

            if (IsPostBack) return;
            if (DisplayMode != Mode.AddUser)
            {
                BindData();
                ShowHidePanels();
            }
            else
            {
                ShowAddUser();
            }
        }

        private void ShowAddUser()
        {
            pnlLocationSelect.Visible = true;
            pnlUserInfo.Visible = false;

            txtCompany.Visible = true;
            txtDepartment.Visible = true;
            txtJobTitle.Visible = true;
            txtEmployeeId.Visible = true;

            lblCompany.Visible = false;
            lblDepartment.Visible = false;
            lblJobTitle.Visible = false;
            lblEmployeeId.Visible = false;

            ubManager.Visible = false;
            tblManager.Visible = true;

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeList"]))
            {
                txtOffice.Visible = false;
            }
            else
            {
                ddlOffice.Visible = false;
                ddlOffice.SelectedValue = "0";
            }

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDepartmentList"]))
            {
                txtDepartment.Visible = false;
            }
            else
            {
                ddlDepartment.Visible = false;
                ddlDepartment.SelectedValue = "0";
            }

            // Turn off non-needed options
            btnRefresh.Visible = false;
            tblManagerRowClear.Visible = false;
            pnlClearPhoto.Visible = false;
            pnlSubmitPhoto.Visible = false;
            pnlActions.Visible = false;
            pnlWizardSteps.Visible = true;
        }

        private void ShowHidePanels()
        {
            // Check master edit switch
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserAttibChanges"]))
            {
                pnlPersonal.Enabled = false;
                pnlLocation.Enabled = false;
                pnlPhone.Enabled = false;
                pnlPhoto.Enabled = false;
                btnSubmit.Enabled = false;
            }

            // Check Name
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserNameChanges"]))
            {
                txtFirstName.Enabled = false;
                txtMiddleName.Enabled = false;
                txtLastName.Enabled = false;
            }

            // Check Email
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserEmailChanges"]))
                txtEmail.Enabled = false;

            // Check Location
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserLocationChanges"]))
                pnlLocation.Enabled = false;

            // Check Photo
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPhotoChanges"]))
                pnlPhoto.Enabled = false;

            // Check Phone
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPhoneChanges"]))
                pnlPhone.Enabled = false;

            // Check Location Display
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserLocationSection"]))
                pnlLocation.Visible = false;

            // Check Phone Display
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserPhoneSection"]))
                pnlPhone.Visible = false;

            // Check Org Display
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserOrganizationSection"]))
                pnlOrg.Visible = false;

            // Check Photo Display
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserPhotoSection"]))
                pnlPhoto.Visible = false;

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeList"]))
            {
                txtOffice.Visible = false;
            }
            else
            {
                ddlOffice.Visible = false;
            }

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDepartmentList"]))
            {
                txtDepartment.Visible = false;
            }
            else
            {
                ddlDepartment.Visible = false;
            }

        }

        private void BindData()
        {
            EmployeeDTO emp;
            if (Page.RouteData.Values.Count == 0)
            {
                emp = (EmployeeDTO)Session["CurrentEmp"];
                SetEditMode(false);
            }
            else
            {
                if (String.IsNullOrWhiteSpace(Page.RouteData.Values["upn"].ToString()))
                {
                    emp = (EmployeeDTO)Session["CurrentEmp"];
                    SetEditMode(false);
                }
                else
                {
                    emp = new Employees().GetEmployeeByUsername(Page.RouteData.Values["upn"].ToString());
                    if (DisplayMode == Mode.ViewUser) SetViewMode();
                    else SetEditMode(true);
                }
            }
            if (emp == null) return;

            // My Info
            txtFirstName.Text = emp.FirstName;
            txtMiddleName.Text = emp.MiddleName;
            txtLastName.Text = emp.LastName;
            txtEmail.Text = emp.Email;
            txtWebsite.Text = emp.Website;
            lFirstName.Text = emp.FirstName;
            lMiddleName.Text = emp.MiddleName;
            lLastName.Text = emp.LastName;
            lEmail.Text = emp.Email;
            lWebsite.Text = emp.Website;

            // Address
            txtOffice.Text = emp.Office;
            lOffice.Text = emp.Office;
            txtAddress1.Text = emp.Address1;
            txtAddress2.Text = emp.Address2;
            txtCity.Text = emp.City;
            txtState.Text = emp.Province;
            txtPostalCode.Text = emp.PostalCode;
            txtCountry.Text = emp.Country;
            lAddress1.Text = emp.Address1;
            lAddress2.Text = emp.Address2;
            lCity.Text = emp.City;
            lState.Text = emp.Province;
            lPostalCode.Text = emp.PostalCode;
            lCountry.Text = emp.Country;

            // Office List logic
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeList"]))
            {
                if (String.IsNullOrWhiteSpace(emp.Office))
                    ddlOffice.SelectedValue = "0";
                else
                {
                    var ao = new Offices();
                    var o = ao.GetOfficeByName(emp.Office);

                    if (o != null)
                        ddlOffice.SelectedValue = o.OfficeId.ToString();
                    else
                    {
                        var i = new ListItem(emp.Office, "USER-DEF");
                        if (!ddlOffice.Items.Contains(i))
                            ddlOffice.Items.Add(i);
                        ddlOffice.SelectedValue = "USER-DEF";
                    }
                }
            }

            // Department List logic
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDepartmentList"]))
            {
                if (String.IsNullOrWhiteSpace(emp.Department))
                    ddlDepartment.SelectedValue = "0";
                else
                {
                    var ao = new Departments();
                    var d = ao.GetDepartmentByName(emp.Department);

                    if (d != null)
                        ddlDepartment.SelectedValue = d.DepartmentId.ToString();
                    else
                    {
                        var i = new ListItem(emp.Department, "USER-DEF");
                        if (!ddlDepartment.Items.Contains(i))
                            ddlDepartment.Items.Add(i);
                        ddlDepartment.SelectedValue = "USER-DEF";
                    }
                }
            }

            // Phone
            txtOfficePhone.Text = emp.OfficePhone;
            txtHomePhone.Text = emp.HomePhone;
            txtMobilePhone.Text = emp.MobilePhone;
            txtPager.Text = emp.Pager;
            txtFax.Text = emp.Fax;
            txtSip.Text = emp.SipPhone;
            lOfficePhone.Text = emp.OfficePhone;
            lHomePhone.Text = emp.HomePhone;
            lMobilePhone.Text = emp.MobilePhone;
            lPager.Text = emp.Pager;
            lFax.Text = emp.Fax;
            lSip.Text = emp.SipPhone;

            // Company Info
            lblCompany.Text = emp.Company;
            lblDepartment.Text = emp.Department;
            lblJobTitle.Text = emp.JobTitle;
            lblEmployeeId.Text = emp.EmployeeId;
            lblBadgeId.Text = emp.BadgeId;
            txtCompany.Text = emp.Company;
            txtDepartment.Text = emp.Department;
            txtJobTitle.Text = emp.JobTitle;
            txtEmployeeId.Text = emp.EmployeeId;
            txtBadgeId.Text = emp.BadgeId;

            // Manager
            ubManager.Employee = emp.Manager;
            txtManager.Text = emp.Manager != null ? emp.Manager.DisplayName : "";

            // Photo
            imgPhoto.ImageUrl = "~/Controls/EmpPhoto.ashx?u=" + Encoder.EncodeString(emp.UpnUsername);
        }

        private void SetViewMode()
        {
            // My Info
            txtFirstName.Visible = false;
            txtMiddleName.Visible = false;
            txtLastName.Visible = false;
            txtEmail.Visible = false;
            txtWebsite.Visible = false;
            lFirstName.Visible = true;
            lMiddleName.Visible = true;
            lLastName.Visible = true;
            lEmail.Visible = true;
            lWebsite.Visible = true;

            txtOffice.Visible = false;
            txtDepartment.Visible = false;
            ddlOffice.Visible = false;
            ddlDepartment.Visible = false;
            lOffice.Visible = true;
            lblDepartment.Visible = true;

            // Address
            txtAddress1.Visible = false;
            txtAddress2.Visible = false;
            txtCity.Visible = false;
            txtState.Visible = false;
            txtPostalCode.Visible = false;
            txtCountry.Visible = false;
            lAddress1.Visible = true;
            lAddress2.Visible = true;
            lCity.Visible = true;
            lState.Visible = true;
            lPostalCode.Visible = true;
            lCountry.Visible = true;

            // Phone
            txtOfficePhone.Visible = false;
            txtHomePhone.Visible = false;
            txtMobilePhone.Visible = false;
            txtPager.Visible = false;
            txtFax.Visible = false;
            txtSip.Visible = false;
            lOfficePhone.Visible = true;
            lHomePhone.Visible = true;
            lMobilePhone.Visible = true;
            lPager.Visible = true;
            lFax.Visible = true;
            lSip.Visible = true;

            pnlActions.Visible = false;

            txtCompany.Visible = false;
            txtDepartment.Visible = false;
            ddlDepartment.Visible = false;
            txtJobTitle.Visible = false;
            txtEmployeeId.Visible = false;
            txtBadgeId.Visible = false;

            lblCompany.Visible = true;
            lblDepartment.Visible = true;
            lblJobTitle.Visible = true;
            lblEmployeeId.Visible = true;
            lblBadgeId.Visible = true;

            ubManager.Visible = true;
            tblManager.Visible = false;

            pnlChangePhoto.Visible = false;
        }

        private void SetEditMode(bool p)
        {
            if (p)
            {
                txtCompany.Visible = true;
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDepartmentList"]))
                    ddlDepartment.Visible = true;
                else
                    txtDepartment.Visible = true;
                txtJobTitle.Visible = true;
                txtEmployeeId.Visible = true;
                txtBadgeId.Visible = true;

                lblCompany.Visible = false;
                lblDepartment.Visible = false;
                lblJobTitle.Visible = false;
                lblEmployeeId.Visible = false;
                lblBadgeId.Visible = false;

                ubManager.Visible = false;
                tblManager.Visible = true;
            }
            else
            {
                txtCompany.Visible = false;
                txtDepartment.Visible = false;
                ddlDepartment.Visible = false;
                txtJobTitle.Visible = false;
                txtEmployeeId.Visible = false;
                txtBadgeId.Visible = false;

                lblCompany.Visible = true;
                lblDepartment.Visible = true;
                lblJobTitle.Visible = true;
                lblEmployeeId.Visible = true;
                lblBadgeId.Visible = true;

                ubManager.Visible = true;
                tblManager.Visible = false;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Startup.LoadUserSessionInfo();
            BindData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (DisplayMode != Mode.AddUser)
            {
                EmployeeDTO emp;
                var emps = new Employees();

                var editMode = false;
                if (Page.RouteData.Values.Count == 0)
                    emp = (EmployeeDTO)Session["CurrentEmp"];
                else
                {
                    if (String.IsNullOrWhiteSpace(Page.RouteData.Values["upn"].ToString()))
                    {
                        emp = (EmployeeDTO)Session["CurrentEmp"];
                    }
                    else
                    {
                        emp = new Employees().GetEmployeeByUsername(Page.RouteData.Values["upn"].ToString());
                        editMode = true;
                    }
                }
                if (emp == null) return;

                // My Info
                emp.FirstName = txtFirstName.Text;
                emp.MiddleName = txtMiddleName.Text;
                emp.LastName = txtLastName.Text;
                emp.Email = txtEmail.Text;
                emp.Website = txtWebsite.Text;

                // Address
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeList"]))
                    emp.Office = ddlOffice.SelectedValue != "0" ? ddlOffice.SelectedItem.Text : "";
                else
                    emp.Office = txtOffice.Text;
                emp.Address1 = txtAddress1.Text;
                emp.Address2 = txtAddress2.Text;
                emp.City = txtCity.Text;
                emp.Province = txtState.Text;
                emp.PostalCode = txtPostalCode.Text;
                emp.Country = txtCountry.Text;

                // Phone
                emp.OfficePhone = txtOfficePhone.Text;
                emp.HomePhone = txtHomePhone.Text;
                emp.MobilePhone = txtMobilePhone.Text;
                emp.Pager = txtPager.Text;
                emp.Fax = txtFax.Text;
                emp.SipPhone = txtSip.Text;

                // Organization
                if (editMode)
                {
                    emp.Company = txtCompany.Text;
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDepartmentList"]))
                        emp.Department = ddlDepartment.SelectedValue != "0" ? ddlDepartment.SelectedItem.Text : "";
                    else
                        emp.Department = txtDepartment.Text;
                    emp.JobTitle = txtJobTitle.Text;
                    emp.EmployeeId = txtEmployeeId.Text;
                    emp.BadgeId = txtBadgeId.Text;

                    if (cbClearManager.Checked)
                        emp.Manager = null;
                    else
                    {
                        if (gvManagerResult.SelectedValue != null)
                            emp.Manager = emps.GetEmployeeByUsername(gvManagerResult.SelectedValue.ToString());
                    }
                }

                if (emps.UpdateEmployee(emp))
                {
                    omResult.Mode = OutputMessage.MessageMode.Success;
                    omResult.Message = "Success! Saved Changes.";
                    omResult.Show();
                    Startup.LoadUserSessionInfo();
                    BindData();
                }
                else
                {
                    omResult.Mode = OutputMessage.MessageMode.Failure;
                    omResult.Message = "Failure! Didn't Save.";
                    omResult.Show();
                }
            }
        }

        protected void btnClearPhoto_Click(object sender, EventArgs e)
        {
            EmployeeDTO emp;
            if (Page.RouteData.Values.Count == 0)
            {
                emp = (EmployeeDTO)Session["CurrentEmp"];
            }
            else
            {
                if (String.IsNullOrWhiteSpace(Page.RouteData.Values["upn"].ToString()))
                {
                    emp = (EmployeeDTO)Session["CurrentEmp"];
                }
                else
                {
                    emp = new Employees().GetEmployeeByUsername(Page.RouteData.Values["upn"].ToString());
                }
            }
            if (emp == null) return;

            var emps = new Employees();
            if (emps.ClearEmployeePhoto(emp.UpnUsername))
            {
                omPhoto.Mode = OutputMessage.MessageMode.Success;
                omPhoto.Message = "Success! Cleared Photo.";
                omPhoto.Show();
                BindData();
            }
            else
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failure! Didn't Save.";
                omResult.Show();
            }
        }

        protected void btnSavePhoto_Click(object sender, EventArgs e)
        {
            EmployeeDTO emp;
            if (Page.RouteData.Values.Count == 0)
            {
                emp = (EmployeeDTO)Session["CurrentEmp"];
            }
            else
            {
                if (String.IsNullOrWhiteSpace(Page.RouteData.Values["upn"].ToString()))
                {
                    emp = (EmployeeDTO)Session["CurrentEmp"];
                }
                else
                {
                    emp = new Employees().GetEmployeeByUsername(Page.RouteData.Values["upn"].ToString());
                }
            }
            if (emp == null) return;
            if (!fuPhoto.HasFile) return;

            var emps = new Employees();
            if (emps.UpdateEmployeePhoto(emp.UpnUsername, fuPhoto.FileBytes))
            {
                omPhoto.Mode = OutputMessage.MessageMode.Success;
                omPhoto.Message = "Success! Updated Photo.";
                omPhoto.Show();
                BindData();
            }
            else
            {
                omPhoto.Mode = OutputMessage.MessageMode.Failure;
                omPhoto.Message = "Failure! Didn't Save.";
                omPhoto.Show();
            }
        }

        protected void lbSearchManager_Click(object sender, EventArgs e)
        {
            var emp = new Employees();
            gvManagerResult.DataSource = emp.SearchForManagers(txtManager.Text).OrderBy(s => s.Value);
            gvManagerResult.DataBind();
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLocation.SelectedValue != "SELECT")
            {
                pnlUserInfo.Visible = true;

                // Load Location Defaults
                var l = new Locations().GetLocation(Guid.Parse(ddlLocation.SelectedValue));
                txtAddress1.Text = l.Address;
                txtCity.Text = l.City;
                txtState.Text = l.Province;
                txtPostalCode.Text = l.PostalCode;
                txtCountry.Text = l.Country;
                txtCompany.Text = l.OrganizationName;
                txtOfficePhone.Text = l.Phone;
            }
            else
            {
                pnlUserInfo.Visible = false;
            }
        }

        protected void Wizard1_ActiveStepChanged(object sender, EventArgs e)
        {
            if (Wizard1.ActiveStepIndex == 1)
            {
                // Capture the photo
                if (fuPhoto.HasFile)
                {
                    lblUploadPath.Text = "~/App_Data/Temp/" + Guid.NewGuid();
                    fuPhoto.SaveAs(Server.MapPath(lblUploadPath.Text));
                    Startup.ClearTempFiles();
                }

                var emps = new Employees();
                var username = emps.BuildUsernameFromName(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text,
                                                          Guid.Parse(ddlLocation.SelectedValue));
                txtUsername.Text = username;
                CheckUserName(username);

                // See if the user should be able to login or if their account should be disabled.
                if (!cbEnable.Checked)
                    rblPassword.Enabled = false;

                // See if user will supply temp password or let system generate it.
                txtPassword.Visible = rblPassword.SelectedValue != "SYS";
                txtPassword.Text = Encoder.GenerateTemporaryPassword();

                var emp = (EmployeeDTO)Session["CurrentEmp"];
                if (emp != null) txtAddEmail.Text = emp.Email;
            }
        }

        private void CheckUserName(string username)
        {
            var emps = new Employees();
            // See if username is available, otherwise force them to change it.)
            if (emps.CheckForExistingUsername(username))
            {
                // Crap, user exists
                txtUsername.Enabled = true;
                lbCheckUsername.Visible = true;
                txtUsername.Text = txtUsername.Text.Substring(0, txtUsername.Text.IndexOf('@'));
                omUsername.Mode = OutputMessage.MessageMode.Failure;
                omUsername.Message = "The system generated username is already in use, please select a different username.";
            }
            else
            {
                // Username is free, just display it instead
                txtUsername.Enabled = false;
                lbCheckUsername.Visible = false;
                omUsername.Mode = OutputMessage.MessageMode.Success;
                omUsername.Message = "The system generated username is available!";
            }
            omUsername.Show();
        }


        protected void lbCheckUsername_Click(object sender, EventArgs e)
        {
            var l = new Locations().GetLocation(Guid.Parse(ddlLocation.SelectedValue));
            txtUsername.Text = txtUsername.Text + "@" + l.Directory;
            CheckUserName(txtUsername.Text);
        }

        protected void rblPassword_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPassword.Visible = rblPassword.SelectedValue != "SYS";
            txtPassword.Text = Encoder.GenerateTemporaryPassword();
        }

        protected void cbEnable_CheckedChanged(object sender, EventArgs e)
        {
            rblPassword.SelectedValue = "SYS";
            rblPassword.Enabled = cbEnable.Checked;
            txtPassword.Visible = rblPassword.SelectedValue != "SYS";
            txtPassword.Text = Encoder.GenerateTemporaryPassword();
        }

        protected void btnSaveClose_OnClick(object sender, EventArgs e)
        {
            // Save the new user
            var emps = new Employees();
            var emp = new EmployeeDTO
                          {
                              UpnUsername = txtUsername.Text,
                              FirstName = txtFirstName.Text,
                              MiddleName = txtMiddleName.Text,
                              LastName = txtLastName.Text,
                              Email = txtEmail.Text,
                              Website = txtWebsite.Text
                          };

            // Address
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeList"]))
                emp.Office = ddlOffice.SelectedValue != "0" ? ddlOffice.SelectedItem.Text : "";
            else
                emp.Office = txtOffice.Text;
            emp.Address1 = txtAddress1.Text;
            emp.Address2 = txtAddress2.Text;
            emp.City = txtCity.Text;
            emp.Province = txtState.Text;
            emp.PostalCode = txtPostalCode.Text;
            emp.Country = txtCountry.Text;

            // Phone
            emp.OfficePhone = txtOfficePhone.Text;
            emp.HomePhone = txtHomePhone.Text;
            emp.MobilePhone = txtMobilePhone.Text;
            emp.Pager = txtPager.Text;
            emp.Fax = txtFax.Text;
            emp.SipPhone = txtSip.Text;

            // Organization
            emp.Company = txtCompany.Text;
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDepartmentList"]))
                emp.Department = ddlDepartment.SelectedValue != "0" ? ddlDepartment.SelectedItem.Text : "";
            else
                emp.Department = txtDepartment.Text;
            emp.JobTitle = txtJobTitle.Text;
            emp.EmployeeId = txtEmployeeId.Text;
            emp.BadgeId = txtBadgeId.Text;

            // Manager
            if (gvManagerResult.SelectedValue != null)
                emp.Manager = emps.GetEmployeeByUsername(gvManagerResult.SelectedValue.ToString());

            // Add user
            var a = emps.AddEmployee(emp, Guid.Parse(ddlLocation.SelectedValue), txtPassword.Text, cbEnable.Checked, txtAddEmail.Text);

            if (a)
            {
                var pic = lblUploadPath.Text;
                var picAdded = false;

                if (!String.IsNullOrWhiteSpace(pic))
                {
                    // Add Photo
                    if (emps.UpdateEmployeePhoto(emp.UpnUsername, pic))
                    {
                        picAdded = true;
                    }
                }

                if (!picAdded && !String.IsNullOrWhiteSpace(pic))
                {
                    omAddUser.Mode = OutputMessage.MessageMode.Failure;
                    omAddUser.Message = "The user was added but their photo could not be uploaded.";
                    omAddUser.Show();
                }
                else
                {
                    Response.Redirect("~/admin/user/add");
                }

                // Dump the photo
                Session["TempUserPhoto"] = String.Empty;
            }
            else
            {
                omAddUser.Mode = OutputMessage.MessageMode.Failure;
                omAddUser.Message = "Failed! The user could not be added.";
                omAddUser.Show();
            }
        }
    }
}
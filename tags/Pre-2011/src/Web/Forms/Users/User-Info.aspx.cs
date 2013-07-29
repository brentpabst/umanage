using System;
using System.Configuration;
using System.Web.UI.WebControls;
using PPI.UMS.AD;
using PPI.UMS.BLL;

namespace PPI.UMS.Web.Forms.Users
{
    public partial class User_Info : System.Web.UI.Page
    {
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (user == null)
                user = new User(User.Identity.Name);

            //Set SubTitle
            this.lblSubTitle.Text = String.Format(Resources.User.Info_SubTitle_Text, user.FirstName);

            if (!IsPostBack)
            {
                BindUserInfo();

                //Check for hidden sections
                CheckForHiddenSection();

                //Disable form elements if needed
                DisableFormElements();
            }
        }

        #region Display Checks

        private void DisableFormElements()
        {
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserAttibChanges"]))
            {
                //Disable all Form elements
                this.pnlAboutMe.Enabled = false;
                this.pnlLocation.Enabled = false;
                this.pnlOrg.Enabled = false;
                this.pnlPhone.Enabled = false;
                this.pnlPic.Enabled = false;
                this.btnSubmit.Visible = false;

                this.dlgMessage.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Warning;
                this.dlgMessage.Title = Resources.User.Info_Disabled_Title;
                this.dlgMessage.Message = Resources.User.Info_Disabled_Message;
                this.dlgMessage.Show();
                return;
            }

            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserNameChanges"]))
            {
                this.txtFirstName.Enabled = false;
                this.txtMiddleName.Enabled = false;
                this.txtLastName.Enabled = false;
            }

            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserEmailChanges"]))
            {
                this.txtEmail.Enabled = false;
            }

            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserLocationChanges"]))
            {
                this.pnlLocation.Enabled = false;
                this.dlgLocation.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Warning;
                this.dlgLocation.Title = Resources.User.Info_Disabled_Title;
                this.dlgLocation.Message = Resources.User.Info_Disabled_Message;
                this.dlgLocation.Show();
            }

            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPhoneChanges"]))
            {
                this.pnlPhone.Enabled = false;
                this.dlgPhone.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Warning;
                this.dlgPhone.Title = Resources.User.Info_Disabled_Title;
                this.dlgPhone.Message = Resources.User.Info_Disabled_Message;
                this.dlgPhone.Show();
            }

            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPhotoChanges"]))
            {
                this.pnlPic.Enabled = false;
                this.dlgPhoto.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Warning;
                this.dlgPhoto.Title = Resources.User.Info_Disabled_Title;
                this.dlgPhoto.Message = Resources.User.Info_Disabled_Message;
                this.dlgPhoto.Show();
            }
        }

        private void CheckForHiddenSection()
        {
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserLocationSection"]))
            {
                this.sldLocation.Visible = false;
                this.pnlLocation.Visible = false;
            }

            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserPhoneSection"]))
            {
                this.sldPhone.Visible = false;
                this.pnlPhone.Visible = false;
            }

            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserOrganizationSection"]))
            {
                this.sldOrg.Visible = false;
                this.pnlOrg.Visible = false;
            }

            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserPhotoSection"]))
            {
                this.sldPhoto.Visible = false;
                this.pnlPic.Visible = false;
            }
        }

        #endregion

        private void BindUserInfo()
        {
            //Personal Info
            this.txtFirstName.Text = user.FirstName;
            this.txtMiddleName.Text = user.MiddleName;
            this.txtLastName.Text = user.LastName;
            this.txtEmail.Text = user.Email;
            this.txtWebsite.Text = user.Website;

            //Location Info
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeLocationList"]))
            {
                //Admin wants to use the dropdown list
                this.txtOffice.Visible = false;
                this.ddlOffice.Visible = true;

                //Bind the list
                this.ddlOffice.DataBind();

                //Good 'ole .NET ddl, make sure the value exists first
                if (!ddlOffice.Items.Contains(new ListItem(user.Office)))
                {
                    ddlOffice.Items.Add(user.Office);
                }
                this.ddlOffice.SelectedValue = user.Office;
            }
            else
            {
                //Admin wants to use the textbox
                this.txtOffice.Visible = true;
                this.ddlOffice.Visible = false;

                this.txtOffice.Text = user.Office;
            }

            this.txtAddress.Text = user.Address1;
            this.txtPOBox.Text = user.Address2;
            this.txtCity.Text = user.City;
            this.txtState.Text = user.State;
            this.txtZip.Text = user.ZipCode;
            this.txtCountry.Text = user.Country;

            //Phone Numbers
            this.txtOfficePhone.Text = user.OfficePhone;
            this.txtHomePhone.Text = user.HomePhone;
            this.txtMobile.Text = user.MobilePhone;
            this.txtPager.Text = user.Pager;
            this.txtFax.Text = user.Fax;
            this.txtIPPhone.Text = user.SIP;

            //Org Info
            this.lblCompany.Text = user.Company;
            this.lblDepartment.Text = user.Department;
            this.uccManager.User = user.Manager;
            this.lblEmployeeId.Text = user.EmployeeID;
            this.lblTitle.Text = user.JobTitle;

            //Photo
            this.imgPhoto.ImageUrl = "~/Controls/UserPhoto.ashx?username=" + user.Username;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Update the local object
            //Personal Info
            user.FirstName = this.txtFirstName.Text;
            user.MiddleName = this.txtMiddleName.Text;
            user.LastName = this.txtLastName.Text;
            user.Email = this.txtEmail.Text;
            user.Website = this.txtWebsite.Text;

            //Photo
            bool photoUpdated = false;
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPhotoChanges"]))
            {
                if (this.cbClearPhoto.Checked)
                {
                    //User wants to remove their picture, so do it
                    photoUpdated = user.ClearUserImage();
                    this.cbClearPhoto.Checked = false;
                }
                else
                {
                    //See if the user has a picture to upload
                    if (this.fuPhoto.HasFile)
                    {
                        //Upload the user's photo                    
                        photoUpdated = user.SaveUserImage(this.fuPhoto.FileBytes);
                    }
                    else
                    {
                        //Nothing really changed we just fake the logic out later in this block
                        photoUpdated = true;
                    }
                }
            }
            else
            {
                //Nothing really changed we just fake the logic out later in this block
                photoUpdated = true;
            }


            //Location Info
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeLocationList"]))
            {
                user.Office = this.ddlOffice.SelectedItem.Text;
            }
            else
            {
                user.Office = this.txtOffice.Text;
            }
            user.Address1 = this.txtAddress.Text;
            user.Address2 = this.txtPOBox.Text;
            user.City = this.txtCity.Text;
            user.State = this.txtState.Text;
            user.ZipCode = this.txtZip.Text;
            user.Country = this.txtCountry.Text;

            //Phone Numbers
            user.OfficePhone = this.txtOfficePhone.Text;
            user.HomePhone = this.txtHomePhone.Text;
            user.MobilePhone = this.txtMobile.Text;
            user.Pager = this.txtPager.Text;
            user.Fax = this.txtFax.Text;
            user.SIP = this.txtIPPhone.Text;

            //Org Info
            user.Company = this.lblCompany.Text;
            user.Department = this.lblDepartment.Text;
            user.EmployeeID = this.lblEmployeeId.Text;
            user.JobTitle = this.lblTitle.Text;

            //Now submit it to the directory
            Messages msg = new Messages();
            string result = "";
            if (user.UpdateUser(out result))
            {
                if (!photoUpdated && !this.cbClearPhoto.Checked)
                {
                    //Log to DB
                    msg.AddMessage(Resources.Messages.User_Photo_Fail_Title, Resources.Messages.User_Photo_Fail_Message, "Photo", false);

                    //Photo did not update
                    this.dlgMessage.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Critical;
                    this.dlgMessage.Title = Resources.User.Info_Change_Photo_Failure_Title;
                    this.dlgMessage.Message = String.Format(Resources.User.Info_Change_Photo_Failure_Message, result);
                    this.dlgMessage.Show();
                }
                else
                {
                    //Log to DB
                    msg.AddMessage(Resources.Messages.User_Info_Change_Title, Resources.Messages.User_Info_Change_Message, "Information", false);

                    //User was changed
                    this.dlgMessage.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Success;
                    this.dlgMessage.Title = Resources.User.Info_Change_Success_Title;
                    this.dlgMessage.Message = Resources.User.Info_Change_Success_Message;
                    this.dlgMessage.Show();
                }
            }
            else
            {
                //Log to DB
                msg.AddMessage(Resources.Messages.User_Info_Fail_Title, String.Format(Resources.Messages.User_Info_Fail_Message, result), "Information", false);

                //User failed to update
                this.dlgMessage.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Critical;
                this.dlgMessage.Title = Resources.User.Info_Change_Failure_Title;
                this.dlgMessage.Message = String.Format(Resources.User.Info_Change_Failure_Message, result);
                this.dlgMessage.Show();
            }
        }
    }
}
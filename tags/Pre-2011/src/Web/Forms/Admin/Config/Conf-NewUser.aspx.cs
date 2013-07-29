using System;
using System.Configuration;
using System.Web.Configuration;
using PPI.UMS.BLL;
using PPI.UMS.BLL.Common;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Boolean.Parse(ConfigurationManager.AppSettings["EnableNewUserCreation"]))
                {
                    this.rblEnableCreation.Items.FindByValue("True").Selected = true;
                }
                else
                {
                    this.rblEnableCreation.Items.FindByValue("False").Selected = true;
                }
                ShowHidePanel();
                LoadConfigData();
            }
        }

        private void LoadConfigData()
        {
            this.txtFormat.Text = ConfigurationManager.AppSettings["NewUsernameFormat"].ToString();
            SetExampleName();

            this.txtDN.Text = ConfigurationManager.AppSettings["NewUserContainer"].ToString();

            this.txtName.Text = ConfigurationManager.AppSettings["CompanyName"].ToString();
            this.txtAddress.Text = ConfigurationManager.AppSettings["CompanyAddress"].ToString();
            this.txtCity.Text = ConfigurationManager.AppSettings["CompanyCity"].ToString();
            this.txtState.Text = ConfigurationManager.AppSettings["CompanyState"].ToString();
            this.txtPostal.Text = ConfigurationManager.AppSettings["CompanyPostal"].ToString();
            this.txtCountry.Text = ConfigurationManager.AppSettings["CompanyCountry"].ToString();
            this.txtPhone.Text = ConfigurationManager.AppSettings["CompanyPhone"].ToString();
        }

        protected void rblEnableCreation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowHidePanel();
            SaveCreationOption();
        }

        private void SaveCreationOption()
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

            config.AppSettings.Settings["EnableNewUserCreation"].Value = this.rblEnableCreation.SelectedValue;

            try
            {
                config.Save();
                Messages msg = new Messages();
                msg.AddMessage(Resources.Messages.Admin_NewUser_Enable_Title, String.Format(Resources.Messages.Admin_NewUser_Enable_Message, this.rblEnableCreation.SelectedItem.Text), "Settings", true);
            }
            catch { }
        }

        private void ShowHidePanel()
        {
            bool Show = Boolean.Parse(this.rblEnableCreation.SelectedItem.Value);
            // Show or hide the options
            if (Show)
            {
                this.pnlOptions.Visible = true;
            }
            else
            {
                this.pnlOptions.Visible = false;
            }
        }

        private void SetExampleName()
        {
            try
            {
                this.lblSampleName.Text = UiHelper.GetNewUsernameFromName("John", "Michael", "Smith", this.txtFormat.Text);
            }
            catch
            {
                this.txtFormat.Text = "";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Save the defaults
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            
            config.AppSettings.Settings["NewUsernameFormat"].Value = this.txtFormat.Text;
            config.AppSettings.Settings["NewUserContainer"].Value = this.txtDN.Text;
            config.AppSettings.Settings["CompanyName"].Value = this.txtName.Text;
            config.AppSettings.Settings["CompanyAddress"].Value = this.txtAddress.Text;
            config.AppSettings.Settings["CompanyCity"].Value = this.txtCity.Text;
            config.AppSettings.Settings["CompanyState"].Value = this.txtState.Text;
            config.AppSettings.Settings["CompanyPostal"].Value = this.txtPostal.Text;
            config.AppSettings.Settings["CompanyCountry"].Value = this.txtCountry.Text;
            config.AppSettings.Settings["CompanyPhone"].Value = this.txtPhone.Text;

            try
            {
                config.Save();

                this.dlg.Title = Resources.Admin.Config_NewUser_Save_Success_Title;
                this.dlg.Message = Resources.Admin.Config_NewUser_Save_Success_Msg;
                this.dlg.Mode = Web.Controls.Dialog.DialogMode.Success;
                this.dlg.Show();

                Messages msg = new Messages();
                msg.AddMessage(Resources.Messages.Admin_NewUser_Save_Title, Resources.Messages.Admin_NewUser_Save_Message, "Settings", true);
            }
            catch (Exception ex)
            {

                this.dlg.Title = Resources.Admin.Config_NewUser_Save_Fail_Title;
                this.dlg.Message = String.Format(Resources.Admin.Config_NewUser_Save_Fail_Msg, ex.Message);
                this.dlg.Mode = Web.Controls.Dialog.DialogMode.Critical;
                this.dlg.Show();
            }
        }

        protected void lbTest_Click(object sender, EventArgs e)
        {
            SetExampleName();
        }
    }
}
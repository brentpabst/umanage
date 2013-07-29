using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using PPI.UMS.BLL;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_Portal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Populate the form
                this.CheckBoxList1.Items[0].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPasswordChanges"]);
                this.CheckBoxList1.Items[6].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserAttibChanges"]);
                this.CheckBoxList1.Items[7].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserNameChanges"]);
                this.CheckBoxList1.Items[8].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserEmailChanges"]);
                this.CheckBoxList1.Items[9].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserLocationChanges"]);
                this.CheckBoxList1.Items[10].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPhoneChanges"]);
                this.CheckBoxList1.Items[11].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPhotoChanges"]);
                this.CheckBoxList1.Items[1].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserAccountNotes"]);
                this.CheckBoxList1.Items[2].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserLocationSection"]);
                this.CheckBoxList1.Items[3].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserPhoneSection"]);
                this.CheckBoxList1.Items[4].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserOrganizationSection"]);
                this.CheckBoxList1.Items[5].Selected = Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserPhotoSection"]);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Save the changes
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

            config.AppSettings.Settings["AllowUserPasswordChanges"].Value = this.CheckBoxList1.Items[0].Selected.ToString();
            config.AppSettings.Settings["AllowUserAttibChanges"].Value = this.CheckBoxList1.Items[6].Selected.ToString();
            config.AppSettings.Settings["AllowUserNameChanges"].Value = this.CheckBoxList1.Items[7].Selected.ToString();
            config.AppSettings.Settings["AllowUserEmailChanges"].Value = this.CheckBoxList1.Items[8].Selected.ToString();
            config.AppSettings.Settings["AllowUserLocationChanges"].Value = this.CheckBoxList1.Items[9].Selected.ToString();
            config.AppSettings.Settings["AllowUserPhoneChanges"].Value = this.CheckBoxList1.Items[10].Selected.ToString();
            config.AppSettings.Settings["AllowUserPhotoChanges"].Value = this.CheckBoxList1.Items[11].Selected.ToString();
            config.AppSettings.Settings["DisplayUserAccountNotes"].Value = this.CheckBoxList1.Items[1].Selected.ToString();
            config.AppSettings.Settings["DisplayUserLocationSection"].Value = this.CheckBoxList1.Items[2].Selected.ToString();
            config.AppSettings.Settings["DisplayUserPhoneSection"].Value = this.CheckBoxList1.Items[3].Selected.ToString();
            config.AppSettings.Settings["DisplayUserOrganizationSection"].Value = this.CheckBoxList1.Items[4].Selected.ToString();
            config.AppSettings.Settings["DisplayUserPhotoSection"].Value = this.CheckBoxList1.Items[5].Selected.ToString();

            try
            {
                config.Save();

                Messages msg = new Messages();
                msg.AddMessage(Resources.Messages.Admin_Portal_Update_Title, Resources.Messages.Admin_Portal_Update_Message, "Settings", true);

                //Show success
                this.Dialog1.Message = Resources.Admin.Config_Portal_Success_Description;
                this.Dialog1.Mode = Web.Controls.Dialog.DialogMode.Success;
                this.Dialog1.Title = Resources.Admin.Config_Portal_Success_Title;
                this.Dialog1.Show();
            }
            catch
            {
                this.Dialog1.Message = Resources.Admin.Config_Portal_Failure_Description;
                this.Dialog1.Mode = Web.Controls.Dialog.DialogMode.Critical;
                this.Dialog1.Title = Resources.Admin.Config_Portal_Failure_Title;
                this.Dialog1.Show();
            }
        }
    }
}
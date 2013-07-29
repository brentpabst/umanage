using System;
using System.Configuration;
using System.Web.Configuration;
using PPI.UMS.BLL;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_OfficeLoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOfficeLocationList"]))
                {
                    this.RadioButtonList1.SelectedValue = "true";
                    this.pnlShowHide.Visible = true;
                }
                else
                {
                    this.RadioButtonList1.SelectedValue = "false";
                    this.pnlShowHide.Visible = false;
                }
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonList1.SelectedValue == "true")
            {
                this.pnlShowHide.Visible = true;
            }
            else
            {
                this.pnlShowHide.Visible = false;
            }

            //Save the changes
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

            config.AppSettings.Settings["EnableOfficeLocationList"].Value = this.RadioButtonList1.SelectedValue;

            try
            {
                config.Save();
                Messages msg = new Messages();
                msg.AddMessage(Resources.Messages.Admin_OfficeLoc_Enable_Title, String.Format(Resources.Messages.Admin_OfficeLoc_Enable_Message, this.RadioButtonList1.SelectedItem.Text), "Settings", true);
            }
            catch { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Locations locs = new Locations();
                if (locs.DisableLocation(this.ddlSelectedLocation.SelectedValue) > 0)
                {

                    Messages msg = new Messages();
                    msg.AddMessage(Resources.Messages.Admin_OfficeLoc_Remove_Title, String.Format(Resources.Messages.Admin_OfficeLoc_Remove_Message, this.ddlSelectedLocation.SelectedItem.Text), "Settings", true);

                    this.dlgEdit.Mode = Web.Controls.Dialog.DialogMode.Success;
                    this.dlgEdit.Title = Resources.Admin.Config_OfficeLoc_Success_Title;
                    this.dlgEdit.Message = Resources.Admin.Config_OfficeLoc_Success_Message;
                    this.dlgEdit.Show();
                }
                else
                {
                    throw new ApplicationException("Not Updated");
                }
            }
            catch (Exception ex)
            {
                this.dlgEdit.Mode = Web.Controls.Dialog.DialogMode.Critical;
                this.dlgEdit.Title = Resources.Admin.Config_OfficeLoc_Failure_Title;
                this.dlgEdit.Message = Resources.Admin.Config_OfficeLoc_Failure_Message + ex.InnerException.Message;
                this.dlgEdit.Show();
            }            

            //Reload the list
            this.ddlSelectedLocation.Items.Clear();
            this.ddlSelectedLocation.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Locations locs = new Locations();
                if (locs.AddLocation(this.txtLocation.Text) > 0)
                {
                    Messages msg = new Messages();
                    msg.AddMessage(Resources.Messages.Admin_OfficeLoc_Add_Title, String.Format(Resources.Messages.Admin_OfficeLoc_Add_Message, this.txtLocation.Text), "Settings", true);

                    this.dlgEdit.Mode = Web.Controls.Dialog.DialogMode.Success;
                    this.dlgEdit.Title = Resources.Admin.Config_OfficeLoc_Success_Title;
                    this.dlgEdit.Message = Resources.Admin.Config_OfficeLoc_Success_Message;
                    this.dlgEdit.Show();
                }
                else
                {
                    throw new ApplicationException("Not Added");
                }
            }
            catch (Exception ex)
            {
                this.dlgEdit.Mode = Web.Controls.Dialog.DialogMode.Critical;
                this.dlgEdit.Title = Resources.Admin.Config_OfficeLoc_Failure_Title;
                this.dlgEdit.Message = Resources.Admin.Config_OfficeLoc_Failure_Message + ex.InnerException.Message;
                this.dlgEdit.Show();
            }
            
            //Reload the list
            this.ddlSelectedLocation.Items.Clear();
            this.ddlSelectedLocation.DataBind();
        }
    }
}
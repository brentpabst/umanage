using System;
using System.Configuration;
using System.Web.UI;
using PPI.UMS.AD;
using PPI.UMS.BLL;
using PPI.UMS.BLL.Common;


namespace PPI.UMS.Web.Forms.Users
{
    public partial class User_Pass : System.Web.UI.Page
    {
        AD.User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtOldPass.CssClass = "textbox-required";
            this.txtNewPass.CssClass = "textbox-required";
            this.txtConfPass.CssClass = "textbox-required";
            Page.SetFocus(this.txtOldPass.ClientID);

            //Build Sub-title label            
            user = new User(User.Identity.Name);
            this.lblSubTitle.Text = UiHelper.FormatPasswordExpirationText(user.FirstName, user.PasswordExpDate);

            //Check to see if we allow pass resets
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["AllowUserPasswordChanges"]))
            {
                this.tblPassChange.Visible = false;
                this.dlgMessage.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Warning;
                this.dlgMessage.Title = Resources.User.Password_Change_Disabled_Title;
                this.dlgMessage.Message = Resources.User.Password_Change_Disabled_Message;
                this.dlgMessage.Show();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Messages msg = new Messages();
            string result;
            if (user.ChangeUserPassword(this.txtOldPass.Text, this.txtNewPass.Text, this.txtConfPass.Text, out result))
            {
                //Log to DB
                msg.AddMessage(Resources.Messages.User_Password_Change_Title, Resources.Messages.User_Password_Change_Message, "Password", false);

                //Password was changed
                this.dlgMessage.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Success;
                this.dlgMessage.Title = Resources.User.Password_Change_Success_Title;
                this.dlgMessage.Message = Resources.User.Password_Change_Success_Message;
                this.dlgMessage.Show();
            }
            else
            {
                //Log to DB
                msg.AddMessage(Resources.Messages.User_Password_Fail_Title, String.Format(Resources.Messages.User_Password_Fail_Message, result), "Password", false);

                //Password failed to update
                this.dlgMessage.Mode = PPI.UMS.Web.Controls.Dialog.DialogMode.Critical;
                this.dlgMessage.Title = Resources.User.Password_Change_Error_Title;
                if (String.IsNullOrWhiteSpace(result))
                    this.dlgMessage.Message = Resources.User.Password_Change_Error_Message;
                else
                    this.dlgMessage.Message = result;
                this.dlgMessage.Show();
            }
        }
    }
}
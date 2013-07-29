using System;
using System.Configuration;
using PPI.UMS.AD;
using PPI.UMS.BLL.Common;

namespace PPI.UMS.Web.Forms.Users
{
    public partial class User_Account : System.Web.UI.Page
    {
        AD.User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = new User(User.Identity.Name);

            this.lblSubTitle.Text = String.Format(Resources.User.MyAccount_SubTitle_Text, user.FirstName);

            this.lblUsername.Text = user.FullUsername;
            this.lblAccountLocked.Text = UiHelper.FormatBoolean(user.AccountLocked);
            this.lblAccountExp.Text = UiHelper.FormatAccountExpirationText(user.AccountExpDate);
            this.lblPasswordExp.Text = UiHelper.FormatPasswordExpirationText(user.PasswordExpDate);
            this.txtNotes.Text = user.Notes;

            //See if we should hide the notes
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["DisplayUserAccountNotes"]))
            {
                this.lblHeadNotes.Visible = false;
                this.txtNotes.Visible = false;
            }
        }
    }
}
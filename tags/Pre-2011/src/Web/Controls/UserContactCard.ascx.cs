using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPI.UMS.Web.Controls
{
    public partial class UserContactCard : System.Web.UI.UserControl
    {
        public string User { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrWhiteSpace(User))
                {
                    AD.User user = new AD.User(User);
                    this.Image1.ImageUrl = "~/Controls/UserPhotoThumbnail.ashx?username=" + user.Username;
                    this.lblName.Text = user.DisplayName;
                    this.lblTitle.Text = user.JobTitle;
                    this.lblPhone.Text = user.OfficePhone;

                    this.HyperLink1.NavigateUrl = "mailto:" + user.Email;
                }
                else
                {
                    this.Visible = false;
                }
            }
        }
    }
}
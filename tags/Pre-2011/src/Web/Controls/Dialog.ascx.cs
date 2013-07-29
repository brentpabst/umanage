using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPI.UMS.Web.Controls
{
    public partial class Dialog : System.Web.UI.UserControl
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DialogMode Mode { get; set; }
        public bool DefaultShow { get; set; }

        public enum DialogMode
        {
            Critical = 1,
            Warning = 2,
            Success = 3,
            Info = 4
        }

        public void Show()
        {
            SetValues();
            this.Visible = true;
        }

        public void Hide()
        {
            this.Visible = false;
        }

        protected void SetValues()
        {
            //Make sure it shows
            this.DefaultShow = true;

            // Set title and message
            this.lblMessage.Text = Message;
            this.lblTitle.Text = Title;

            //Set CSS Class
            switch (Mode)
            {
                case DialogMode.Critical:
                    this.dialogdiv.Attributes["class"] = "dialog critical";
                    break;
                case DialogMode.Info:
                    this.dialogdiv.Attributes["class"] = "dialog info";
                    break;
                case DialogMode.Success:
                    this.dialogdiv.Attributes["class"] = "dialog success";
                    break;
                case DialogMode.Warning:
                    this.dialogdiv.Attributes["class"] = "dialog warning";
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Hide();
            }
            if (!DefaultShow)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }
}
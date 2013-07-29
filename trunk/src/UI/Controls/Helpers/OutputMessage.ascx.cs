namespace THS.UMS.UI.Controls.Helpers
{
    using System;

    public partial class OutputMessage : System.Web.UI.UserControl
    {
        public string Message { get; set; }
        public MessageMode Mode { get; set; }
        public bool NoMargin { get; set; }
        public enum MessageMode
        {
            Success,
            Failure
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Hide();
        }

        private void Hide()
        {
            this.Visible = false;
        }

        public void Show()
        {
            this.lblOutput.Text = Message;

            var margin = ".output_nomargin";
            if (!NoMargin) margin = ".output";

            switch (Mode)
            {
                case MessageMode.Success:
                    this.lblOutput.CssClass = margin + " success";
                    break;
                case MessageMode.Failure:
                    this.lblOutput.CssClass = margin + " failure";
                    break;
            }

            this.Visible = true;
        }
    }
}
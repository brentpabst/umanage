using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPI.UMS.Web.Controls
{
    public partial class SlidingPanel : System.Web.UI.UserControl
    {
        public string TargetControlID { get; set; }
        public string HeaderTitle { get; set; }
        public bool Expanded { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Expanded)
                Expanded = false;
            else
                Expanded = true;

            this.CollapsiblePanelExtender1.Collapsed = Expanded;
            this.CollapsiblePanelExtender1.TargetControlID = TargetControlID;
            this.lblOptions.Text = HeaderTitle;
        }
    }
}
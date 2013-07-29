namespace THS.UMS.UI.Forms.Admin
{
    using System;
    using System.Web.UI.WebControls;

    using THS.UMS.DTO;

    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int _tUserCount;
        private int _tAccountExpired;
        private int _tPasswordExpired;
        private int _tAccountExp;
        private int _tPasswordExp;

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Reference the ProductsRow via the e.Row.DataItem property
                var d = (MetricDTO) e.Row.DataItem;

                // Increment the running totals
                _tUserCount += d.TotalUserCount;
                _tAccountExpired += d.ExpiredAccountCount;
                _tPasswordExpired += d.ExpiredPasswordCount;
                _tAccountExp += d.ExpiringAccountCount;
                _tPasswordExp += d.ExpiringPasswordCount;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = _tUserCount.ToString();
                e.Row.Cells[3].Text = _tAccountExpired.ToString();
                e.Row.Cells[4].Text = _tPasswordExpired.ToString();
                e.Row.Cells[5].Text = _tAccountExp.ToString();
                e.Row.Cells[6].Text = _tPasswordExp.ToString();
            }
        }
    }
}
namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;
    using System.Data.SqlClient;

    public partial class SysDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            var c = new Utilities.Config();
            var e = c.GetDatabaseSettings();
            var s = new SqlConnectionStringBuilder(e.ProviderConnectionString);

            txtServer.Text = s.DataSource;
            txtCatalog.Text = s.InitialCatalog;
            txtUser.Text = !s.IntegratedSecurity ? s.UserID : "Integrated Security";
        }
    }
}
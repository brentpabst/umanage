using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.EntityClient;
using System.Configuration;
using System.Data.SqlClient;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_Database : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Connection String
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder eConn = new EntityConnectionStringBuilder();
            eConn.ConnectionString = ConfigurationManager.ConnectionStrings["uManageEntities"].ConnectionString;
            conn.ConnectionString = eConn.ProviderConnectionString;

            //Assign values
            this.txtServer.Text = conn.DataSource;
            this.txtCatalog.Text = conn.InitialCatalog;
            if (!conn.IntegratedSecurity)
                this.txtUsername.Text = conn.UserID;
            else
                this.txtUsername.Text = "Integrated Authentication";
        }
    }
}
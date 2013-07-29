using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using PPI.UMS.BLL;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_Domain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Show the username and domain currently in place
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                ConnectionStringsSection cs = (ConnectionStringsSection)config.GetSection("connectionStrings");

                this.txtADFQDN.Text = cs.ConnectionStrings["ADService"].ConnectionString.Substring(7);

                MembershipSection ms = (MembershipSection)config.GetSection("system.web/membership");
                ProviderSettings ps = ms.Providers["AspNetActiveDirectoryMembershipProvider"];

                this.txtADUsername.Text = ps.Parameters["connectionUsername"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Messages msg = new Messages();

            //Verify the information passed in
            string server;
            Installer inst = new Installer();
            if (!inst.VerifyDomainCredentials(this.txtADFQDN.Text, this.txtADUsername.Text, this.txtADPassword.Text, out server))
            {
                //Log to DB
                msg.AddMessage(Resources.Messages.Admin_Domain_Fail_Title, Resources.Messages.Admin_Domain_Fail_Message, "Domain", true);

                //The settings were invalid!
                this.dlgADMessage.Message = Resources.Setup.Setup_Error_Domain_Message;
                this.dlgADMessage.Mode = Web.Controls.Dialog.DialogMode.Critical;
                this.dlgADMessage.Title = Resources.Setup.Setup_Error_Domain_Title;
                this.dlgADMessage.Show();
            }
            else
            {
                //Save the changes
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                ConnectionStringsSection cs = (ConnectionStringsSection)config.GetSection("connectionStrings");
                cs.ConnectionStrings["ADService"].ConnectionString = "ldap://" + this.txtADFQDN.Text;
                MembershipSection ms = (MembershipSection)config.GetSection("system.web/membership");
                ProviderSettings ps = ms.Providers["AspNetActiveDirectoryMembershipProvider"];
                ps.Parameters.Set("connectionUsername", this.txtADUsername.Text);
                ps.Parameters.Set("connectionPassword", this.txtADPassword.Text);

                //Save config changes
                config.Save();

                //Log to DB
                msg.AddMessage(Resources.Messages.Admin_Domain_Updated_Title, String.Format(Resources.Messages.Admin_Domain_Updated_Message, this.txtADUsername.Text), "Domain", true);

                //The settings were valid!
                this.dlgADMessage.Message = String.Format(Resources.Admin.Config_Domain_Success_Message, server);
                this.dlgADMessage.Mode = Web.Controls.Dialog.DialogMode.Success;
                this.dlgADMessage.Title = Resources.Admin.Config_Domain_Success_Title;
                this.dlgADMessage.Show();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

namespace PPI.UMS.Web.Forms.Admin.Config
{
    public partial class Conf_MsftTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableMsftTag"]))
                {
                    this.cbEnable.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableMsftTag"]);
                    this.txtApiKey.Text = ConfigurationManager.AppSettings["MsftTagApiKey"];
                    this.txtApiKey.Enabled = true;
                }
            }
        }

        protected void cbEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.cbEnable.Checked)
            {
                this.txtApiKey.Enabled = false;
            }
            else
            {
                this.txtApiKey.Enabled = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

            //Save Config
            config.AppSettings.Settings["EnableMsftTag"].Value = this.cbEnable.Checked.ToString();
            config.AppSettings.Settings["MsftTagApiKey"].Value = this.txtApiKey.Text;

            try
            {
                config.Save();

                Dialog1.Title = "Microsoft Tag Updated";
                Dialog1.Message = "The configuration changes to Microsoft Tag have been updated successfully.";
                Dialog1.Mode = Web.Controls.Dialog.DialogMode.Success;
            }
            catch
            {
                Dialog1.Title = "Changes Failed!";
                Dialog1.Message = "When attempting to update Microsoft Tag settings the system failed to save them.  Please try again.";
                Dialog1.Mode = Web.Controls.Dialog.DialogMode.Critical;
            }

            Dialog1.Show();


        }
    }
}
namespace THS.UMS.UI.Forms.Admin.Config
{
    using System;

    using THS.UMS.AO;
    using THS.UMS.UI.Controls.Helpers;

    public partial class AppTemplates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlTemplates.SelectedValue == "") eTemplate.Content = "";
                
            var t = new Emails().GetEmailTemplate(Guid.Parse(ddlTemplates.SelectedValue));
            if (t == null) return;

            eTemplate.Content = t.Body;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlTemplates.SelectedValue == "") return;

            var em = new Emails();
            if (em.UpdateEmailTemplateBody(Guid.Parse(ddlTemplates.SelectedValue),eTemplate.Content))
            {
                omResult.Mode = OutputMessage.MessageMode.Success;
                omResult.Message = "Success! Modified the e-mail template.";
                omResult.Show();
            }
            else
            {
                omResult.Mode = OutputMessage.MessageMode.Failure;
                omResult.Message = "Failed! Could not save the template.";
                omResult.Show();
            }

            ddlTemplates.SelectedIndex = 0;
            eTemplate.Content = "";
        }
    }
}
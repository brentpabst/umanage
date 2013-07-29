namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;

    using THS.UMS.DTO;
    using THS.UMS.EF;

    public class Emails
    {
        /// <summary>
        /// Gets the active email.
        /// </summary>
        /// <returns></returns>
        public List<EmailDTO> GetActiveEmail()
        {
            using (var ctx = new AppEntities())
            {
                var c = Convert.ToInt32(ConfigurationManager.AppSettings["EmailMaxAttemptCount"]);
                var r = new List<EmailDTO>();
                foreach (var e in ctx.Emails.Where(m => !m.IsComplete))
                {
                    if (e.Attempts != null)
                    {
                        if (e.Attempts < c)
                            r.Add(BuildEmailFromEntity(e));
                    }
                    else
                        r.Add(BuildEmailFromEntity(e));
                }
                return r;
            }
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public EmailDTO GetEmail(Guid key)
        {
            using (var ctx = new AppEntities())
            {
                return BuildEmailFromEntity(ctx.Emails.Where(e => e.EmailId == key).FirstOrDefault());
            }
        }

        /// <summary>
        /// Adds the email.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        public bool AddEmail(EmailDTO m)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var e = new Email
                    {
                        EmailId = Guid.NewGuid(),
                        Address = m.Address,
                        Subject = m.Subject,
                        Body = m.Body,
                        SubmittedOn = DateTime.UtcNow,
                        EffectiveDate = m.EffectiveDate
                    };

                    ctx.Emails.AddObject(e);
                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates the email.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        public bool UpdateEmail(EmailDTO m)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var e = ctx.Emails.Where(em => em.EmailId == m.EmailId).FirstOrDefault();
                    if (e == null) return false;

                    e.StartedOn = m.StartedOn;
                    e.CompletedOn = m.CompletedOn;
                    e.Attempts = m.Attempts;
                    e.IsComplete = m.IsComplete;

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets the email template.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public EmailTemplateDTO GetEmailTemplate(Guid id)
        {
            using (var ctx = new AppEntities())
            {
                return BuildEmailTemplateFromEntity(ctx.EmailTemplates.Where(e => e.TemplateId == id).FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the email template.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public EmailTemplateDTO GetEmailTemplate(string title)
        {
            using (var ctx = new AppEntities())
            {
                return BuildEmailTemplateFromEntity(ctx.EmailTemplates.Where(e => e.Title == title).FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the email template list.
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<Guid, string>> GetEmailTemplateList()
        {
            using (var ctx = new AppEntities())
            {
                var r = new List<KeyValuePair<Guid, string>>();
                foreach (var t in ctx.EmailTemplates.Where(c => c.IsEnabled))
                {
                    r.Add(new KeyValuePair<Guid, string>(t.TemplateId, t.Title));
                }
                return r.OrderBy(c => c.Value).ToList();
            }
        }

        /// <summary>
        /// Updates the email template body.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="body">The body.</param>
        /// <returns></returns>
        public bool UpdateEmailTemplateBody(Guid id, string body)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var t = ctx.EmailTemplates.Where(c => c.TemplateId == id).FirstOrDefault();
                    if (t == null) return false;

                    t.Body = body;
                    t.UpdatedOn = DateTime.Now;
                    t.UpdatedBy = HttpContext.Current.User.Identity.Name;

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Builds the email template from entity.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        private static EmailTemplateDTO BuildEmailTemplateFromEntity(EmailTemplate t)
        {
            if (t == null) return null;

            return new EmailTemplateDTO
            {
                TemplateId = t.TemplateId,
                Title = t.Title,
                Body = t.Body,
                CreatedOn = t.CreatedOn,
                UpdatedOn = t.UpdatedOn,
                CreatedBy = t.CreatedBy,
                UpdatedBy = t.UpdatedBy,
                IsEnabled = t.IsEnabled
            };
        }

        /// <summary>
        /// Builds the email from entity.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        private static EmailDTO BuildEmailFromEntity(Email e)
        {
            if (e == null) return null;

            return new EmailDTO
                       {
                           EmailId = e.EmailId,
                           Address = e.Address,
                           Subject = e.Subject,
                           Body = e.Body,
                           SubmittedOn = e.SubmittedOn,
                           StartedOn = e.StartedOn,
                           CompletedOn = e.CompletedOn,
                           EffectiveDate = e.EffectiveDate,
                           Attempts = e.Attempts.HasValue ? e.Attempts.Value : 0,
                           IsComplete = e.IsComplete
                       };
        }
    }
}

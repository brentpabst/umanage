namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;

    using THS.UMS.AD;
    using THS.UMS.DTO;
    using THS.UMS.EF;

    public class Notices
    {
        /// <summary>
        /// Gets the expiration notices for all locations.
        /// </summary>
        /// <returns></returns>
        public List<NoticeDTO> GetExpirationNotices()
        {
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));

            var notices = new List<NoticeDTO>();
            foreach (var l in new Locations().GetActiveLocations())
            {
                // Search for Expiring Passwords
                foreach (var e in u.GetUsersWithExpiringPasswords(l.Directory, l.DistinguishedPath))
                {
                    if (e == null) continue;

                    var note = BuildNoticeFromUser(e, NoticeType.PasswordExpiration);
                    if (note != null)
                        notices.Add(note);
                }

                // Search for Expiring Accounts
                foreach (var e in u.GetUsersWithExpiringAccounts(l.Directory, l.DistinguishedPath))
                {
                    if (e == null) continue;

                    var note = BuildNoticeFromUser(e, NoticeType.AccountExpiration);
                    if (note != null)
                        notices.Add(note);
                }
            }

            var retVal = new List<NoticeDTO>();
            foreach (var n in notices.Where(n => n.UsernameUpn != null))
            {
                using (var ctx = new AppEntities())
                {
                    var t = n.Type.ToString();

                    var note = (from o in ctx.Notices
                                where o.UsernameUpn == n.UsernameUpn
                                where o.Type == t
                                orderby o.NoticeDate descending
                                select o).FirstOrDefault();

                    if (note != null)
                    {
                        if (note.NoticeDate <= DateTime.Today.AddDays(-7))
                            retVal.Add(n);
                    }
                    else retVal.Add(n);
                }
            }
            return retVal;
        }

        /// <summary>
        /// Adds the notice.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public bool AddNotice(NoticeDTO n)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var e = new Notice
                    {
                        NoticeId = n.NoticeId,
                        Username = n.Username,
                        UsernameUpn = n.UsernameUpn,
                        NoticeDate = n.NoticeDate,
                        Type = n.Type.ToString(),
                        DisplayName = n.DisplayName,
                        ExpirationDate = n.ExpirationDate,
                        EmailAddress = n.EmailAddress,
                        FirstName = n.FirstName
                    };

                    ctx.Notices.AddObject(e);
                    ctx.SaveChanges();

                    var mail = new Emails();
                    var msg = new EmailDTO
                                  {
                                      Address = e.EmailAddress,
                                      EffectiveDate = DateTime.UtcNow,
                                      Subject =
                                          n.Type == NoticeType.AccountExpiration
                                              ? "User Account Expiration Reminder"
                                              : "Password Expiration Reminder"
                                  };

                    var emp = new Employees().GetEmployeeByUsername(e.UsernameUpn);
                    var d = EmailReplacements.GetReplacementDictionary(emp);
                    d.Add("$title$", AppSettings.GetValue("AppTitle"));
                    d.Add("$link$", AppSettings.GetValue("AppUrl"));

                    var t = mail.GetEmailTemplate(msg.Subject).Body;
                    msg.Body = EmailReplacements.ReplaceTemplateWithDictionary(t, d);

                    mail.AddEmail(msg);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Builds the notice from user principal object.
        /// </summary>
        /// <param name="u">The u.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static NoticeDTO BuildNoticeFromUser(Principal u, NoticeType type)
        {
            var e = new Employees().GetEmployeeByUsername(u.UserPrincipalName);
            if (e == null) return null;

            var n = new NoticeDTO
            {
                NoticeId = Guid.NewGuid(),
                Username = e.Username,
                UsernameUpn = e.UpnUsername,
                DisplayName = e.DisplayName,
                Type = type,
                ExpirationDate = type == NoticeType.AccountExpiration ? e.AccountExpDate : e.PasswordExpDate,
                NoticeDate = DateTime.Now,
                EmailAddress = e.Email,
                FirstName = e.FirstName
            };

            if (n.ExpirationDate == DateTime.MaxValue || n.ExpirationDate == DateTime.MinValue)
                return null;
            return n;
        }
    }
}

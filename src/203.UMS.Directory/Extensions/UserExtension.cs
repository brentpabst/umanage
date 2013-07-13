using _203.UMS.Models.Directory;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace _203.UMS.Directory.Extensions
{
    public static class UserExtension
    {
        public static User AsUser(this UserPrincipal user)
        {
            return HydrateFromPrincipal(user);
        }

        public static UserPrincipal MergeUser(this UserPrincipal principal, User user)
        {
            return MergePrincipalWithUser(principal, user);
        }

        public static IQueryable<User> AsUserQueryable(this IEnumerable<UserPrincipal> users)
        {
            return users.Select(HydrateFromPrincipal).AsQueryable();
        }

        private static User HydrateFromPrincipal(UserPrincipal p)
        {
            var e = p.GetUnderlyingObject() as DirectoryEntry;
            var pass = new PasswordExpiration();
            return new User
                       {
                           UserId = p.Guid.GetValueOrDefault(),
                           UserName = p.UserPrincipalName.ToLower(),
                           NtUserName = p.SamAccountName,
                           DistinguishedName = p.DistinguishedName,
                           IsLocked = p.IsAccountLockedOut(),
                           IsDisabled = !p.Enabled.GetValueOrDefault(),
                           IsExpired = p.AccountExpirationDate.HasValue && p.AccountExpirationDate.GetValueOrDefault() <= DateTime.UtcNow,
                           ExpiresOn = p.AccountExpirationDate.GetValueOrDefault(),
                           PasswordExpiresOn = pass.GetExpiration(e),

                           Name = p.Name,
                           DisplayName = p.DisplayName,
                           FirstName = p.GivenName,
                           MiddleName = p.MiddleName,
                           LastName = p.Surname,
                           Email = p.EmailAddress,
                           Website = e.GetProperty("wWWHomePage"),

                           Organization = e.GetProperty("company"),
                           Department = e.GetProperty("department"),
                           Title = e.GetProperty("title"),
                           Office = e.GetProperty("physicalDeliveryOfficeName"),
                           EmployeeId = e.GetProperty("employeeNumber"),
                           BadgeId = e.GetProperty("employeeID"),

                           Address1 = e.GetProperty("streetAddress"),
                           Address2 = e.GetProperty("postOfficeBox"),
                           City = e.GetProperty("l"),
                           Province = e.GetProperty("st"),
                           PostCode = e.GetProperty("postalCode"),
                           Country = e.GetProperty("c"),

                           HomePhone = e.GetProperty("homephone"),
                           OfficePhone = p.VoiceTelephoneNumber,
                           MobilePhone = e.GetProperty("mobile"),
                           SipPhone = e.GetProperty("ipPhone"),
                           Pager = e.GetProperty("pager"),
                           Fax = e.GetProperty("facsimileTelephoneNumber"),
                       };
        }

        private static UserPrincipal MergePrincipalWithUser(UserPrincipal p, User u)
        {
            var e = p.GetUnderlyingObject() as DirectoryEntry;

            // Build User Principal Assignments here
            p.GivenName = u.FirstName;
            p.MiddleName = u.MiddleName;
            p.Surname = u.LastName;
            p.EmailAddress = u.Email;
            p.VoiceTelephoneNumber = u.OfficePhone;
            p.DisplayName = u.DisplayName;

            e.SetProperty("wWWHomePage", u.Website);
            e.SetProperty("title", u.Title);
            e.SetProperty("physicalDeliveryOfficeName", u.Office);
            e.SetProperty("company", u.Organization);
            e.SetProperty("department", u.Department);
            e.SetProperty("employeeID", u.BadgeId);
            e.SetProperty("employeeNumber", u.EmployeeId);
            //e.SetProperty("manager", u.Manager != null ? u.Manager.DistinguishedName : null);
            e.SetProperty("streetAddress", u.Address1);
            e.SetProperty("postOfficeBox", u.Address2);
            e.SetProperty("l", u.City);
            e.SetProperty("postalCode", u.PostCode);
            e.SetProperty("st", u.Province);
            e.SetProperty("c", u.Country);
            e.SetProperty("homephone", u.HomePhone);
            e.SetProperty("pager", u.Pager);
            e.SetProperty("mobile", u.MobilePhone);
            e.SetProperty("facsimileTelephoneNumber", u.Fax);
            e.SetProperty("ipPhone", u.SipPhone);

            return p;
        }
    }
}

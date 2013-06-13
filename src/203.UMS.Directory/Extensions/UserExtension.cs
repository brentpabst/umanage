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
    }
}

using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using uManange.Models;

namespace uManage.Directories.ActiveDirectory
{
    internal static class UserExtensions
    {
        /// <summary>
        /// Formats a User Principal as a User object.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        internal static User AsUser(this UserPrincipal user)
        {
            return HydrateFromPrincipal(user);
        }

        /// <summary>
        /// Merges the User object with a User Principal.
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        internal static UserPrincipal MergeUser(this UserPrincipal principal, User user)
        {
            return MergePrincipalWithUser(principal, user);
        }

        /// <summary>
        /// Formats a collection of Users 
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        internal static IQueryable<User> AsUserQueryable(this IEnumerable<UserPrincipal> users)
        {
            return users.Select(HydrateFromPrincipal).AsQueryable();
        }

        /// <summary>
        /// Hydrates from principal.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        private static User HydrateFromPrincipal(UserPrincipal p)
        {
            var e = p.GetUnderlyingObject() as DirectoryEntry;
            var pass = new PasswordExpiration();
            return new User
            {
                UserId = p.Guid.GetValueOrDefault(),
                UserPrincipalName = p.UserPrincipalName.ToLower(),
                NtUserName = p.SamAccountName,
                DistinguishedName = p.DistinguishedName,
                AccountIsLocked = p.IsAccountLockedOut(),
                AccountIsDisabled = !p.Enabled.GetValueOrDefault(),
                AccountIsExpired = p.AccountExpirationDate.HasValue && p.AccountExpirationDate.GetValueOrDefault() <= DateTime.UtcNow,
                AccountExpires = p.AccountExpirationDate.HasValue,
                AccountExpirationDate = p.AccountExpirationDate.HasValue ? p.AccountExpirationDate.GetValueOrDefault() : new DateTime?(),
                PasswordIsExpired = pass.GetExpiration(e) == DateTime.MinValue,
                PasswordExpires = pass.GetExpiration(e) != DateTime.MaxValue,
                PasswordExpirationDate = pass.GetExpiration(e),
                PasswordLastSetDate = pass.GetLastSet(e),

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

        /// <summary>
        /// Merges the principal with user.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="u">The u.</param>
        /// <returns></returns>
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

namespace THS.UMS.AD
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;

    using THS.UMS.DTO;

    public class Users
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Users"/> class.
        /// </summary>
        public Users(string user, string pass)
        {
            _connectionUsername = user;
            _connectionPassword = pass;
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets the user principal by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public UserPrincipal GetUserPrincipalByUsername(string username)
        {
            return !String.IsNullOrWhiteSpace(username) ? GetUserPrincipalByUsername(username, GetDomainNameFromUsername(username)) : null;
        }

        /// <summary>
        /// Gets the user principal by username and domain name.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="domain">The domain.</param>
        /// <returns></returns>
        public UserPrincipal GetUserPrincipalByUsername(string username, string domain)
        {
            if (!String.IsNullOrWhiteSpace(username) || !String.IsNullOrWhiteSpace(domain))
            {
                if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
                {
                    using (var context = GetPrincipalContext(domain))
                    {
                        try
                        {
                            var userPrincipal = UserPrincipal.FindByIdentity(context, username);
                            return userPrincipal;
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    }
                }
                return null;
            }
            return null;
        }
        
        /// <summary>
        /// Gets the group users.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="domain">The domain.</param>
        /// <returns></returns>
        public List<UserPrincipal> GetGroupUsers(string group, string domain)
        {
            if (String.IsNullOrWhiteSpace(group)) return null;
            if (String.IsNullOrWhiteSpace(_connectionUsername) && String.IsNullOrWhiteSpace(_connectionPassword)) return null;

            var ctx = GetPrincipalContext(domain);

            var g = GroupPrincipal.FindByIdentity(ctx, group);
            if (g == null) return null;

            return g.GetMembers(true).OfType<UserPrincipal>().Select(p => GetUserPrincipalByUsername(p.UserPrincipalName)).ToList();
        }

        /// <summary>
        /// Searches for users in a given domain.
        /// </summary>
        /// <param name="query">The name to search for.</param>
        /// <param name="domain">The domain to use.</param>
        /// <returns></returns>
        public List<UserPrincipal> SearchAllUsers(string query, string domain)
        {
            if (!String.IsNullOrWhiteSpace(query))
            {
                if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
                {
                    using (var context = GetPrincipalContext(domain))
                    {
                        try
                        {
                            // Create an in-memory user object to use as the query example.
                            var u = new UserPrincipal(context) { DisplayName = "*" + query + "*" };
                            //Do not show disabled accounts
                            u.Enabled = true;
                            // Run the query. The query locates users 
                            // that match the supplied user principal object. 
                            using (var ps = new PrincipalSearcher(u))
                            {
                                ps.QueryFilter = u;
                                return ps.FindAll().OfType<UserPrincipal>().ToList();
                            }
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    }
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Gets the users with expiring passwords.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="locDn">The distinguished name.</param>
        /// <returns></returns>
        public List<UserPrincipal> GetUsersWithExpiringPasswords(string domain, string locDn)
        {
            if (String.IsNullOrWhiteSpace(domain)) return null;
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain, locDn))
                {
                    try
                    {
                        var empty = new List<UserPrincipal>();
                        // Get Domain Policy
                        var maxPwdAge = new PasswordExpiration().Policy.MaxPasswordAge;
                        if (maxPwdAge == TimeSpan.MaxValue) return empty;

                        // Create query principal object
                        var qUser = new UserPrincipal(context);
                        qUser.AdvancedSearchFilter.LastPasswordSetTime(DateTime.Now, MatchType.LessThanOrEquals);
                        qUser.AdvancedSearchFilter.LastPasswordSetTime(DateTime.Now.AddDays(-maxPwdAge.TotalDays),
                                                                        MatchType.GreaterThanOrEquals);

                        var s = new PrincipalSearcher(qUser);
                        return s.FindAll().OfType<UserPrincipal>().Where(l => l.UserPrincipalName != null).ToList();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the users with expiring accounts.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="locDn">The distinguished name.</param>
        /// <returns></returns>
        public List<UserPrincipal> GetUsersWithExpiringAccounts(string domain, string locDn)
        {
            if (String.IsNullOrWhiteSpace(domain)) return null;
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain, locDn))
                {
                    try
                    {
                        // Create query principal object
                        var qUser = new UserPrincipal(context);
                        qUser.AdvancedSearchFilter.AccountExpirationDate(DateTime.Now.AddMonths(1),
                                                                         MatchType.LessThanOrEquals);
                        qUser.AdvancedSearchFilter.AccountExpirationDate(DateTime.Now, MatchType.GreaterThanOrEquals);

                        var s = new PrincipalSearcher(qUser);
                        var retVal = s.FindAll().OfType<UserPrincipal>();
                        return retVal.Where(l => l.UserPrincipalName != null && l.AccountExpirationDate != null).ToList();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Updates the user principal using the employee object.
        /// </summary>
        /// <param name="e">The employee object.</param>
        /// <param name="domain">The domain.</param>
        /// <returns></returns>
        public bool UpdateUserPrincipalByEmployee(EmployeeDTO e, string domain)
        {
            if (e != null)
            {
                try
                {
                    // Get User Principal
                    var u = GetUserPrincipalByUsername(e.Username, domain);

                    // Update simple values
                    u.GivenName = e.FirstName;
                    u.Surname = e.LastName;
                    u.MiddleName = String.IsNullOrWhiteSpace(e.MiddleName) ? null : e.MiddleName;
                    u.EmailAddress = String.IsNullOrWhiteSpace(e.Email) ? null : e.Email;
                    u.VoiceTelephoneNumber = String.IsNullOrWhiteSpace(e.OfficePhone) ? null : e.OfficePhone;

                    // Display Name
                    var dn = BuildDisplayName(e.FirstName, e.MiddleName, e.LastName);
                    u.DisplayName = String.IsNullOrWhiteSpace(dn) ? null : dn;

                    // Update complex values
                    var d = (DirectoryEntry)u.GetUnderlyingObject();
                    SetProperty(d, "initials", e.MiddleName.Length > 1 ? e.MiddleName.Remove(1) : e.MiddleName);
                    SetProperty(d, "streetAddress", e.Address1);
                    SetProperty(d, "physicalDeliveryOfficeName", e.Office);
                    SetProperty(d, "wWWHomePage", e.Website);
                    SetProperty(d, "postOfficeBox", e.Address2);
                    SetProperty(d, "l", e.City);
                    SetProperty(d, "st", e.Province);
                    SetProperty(d, "postalCode", e.PostalCode);
                    SetProperty(d, "c", e.Country);
                    SetProperty(d, "homephone", e.HomePhone);
                    SetProperty(d, "pager", e.Pager);
                    SetProperty(d, "mobile", e.MobilePhone);
                    SetProperty(d, "facsimileTelephoneNumber", e.Fax);
                    SetProperty(d, "ipPhone", e.SipPhone);
                    SetProperty(d, "employeeID", e.BadgeId);
                    SetProperty(d, "employeeNumber", e.EmployeeId);
                    SetProperty(d, "title", e.JobTitle);
                    SetProperty(d, "department", e.Department);
                    SetProperty(d, "company", e.Company);
                    SetProperty(d, "info", e.Notes);

                    // Set Manager
                    SetProperty(d, "manager", e.Manager != null ? e.Manager.DistinguishedName : "");

                    // Save User
                    d.CommitChanges();
                    u.Save();

                    // Return
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds the user principal by employee.
        /// </summary>
        /// <param name="e">The employee to add.</param>
        /// <param name="location">The location.</param>
        /// <param name="password">The password.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <returns></returns>
        public bool AddUserPrincipalByEmployee(EmployeeDTO e, LocationDTO location, string password, bool enabled)
        {
            if (String.IsNullOrWhiteSpace(e.UpnUsername) || String.IsNullOrWhiteSpace(location.Directory)) return false;
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(location.Directory, location.DistinguishedPath))
                {
                    try
                    {
                        // Check if username is in use
                        if (UserPrincipal.FindByIdentity(context, e.UpnUsername) != null) return false;

                        var up = new UserPrincipal(context)
                        {
                            Name = BuildDisplayName(e.FirstName, e.MiddleName, e.LastName),
                            DisplayName = BuildDisplayName(e.FirstName, e.MiddleName, e.LastName),

                            GivenName = String.IsNullOrWhiteSpace(e.FirstName) ? null : e.FirstName,
                            MiddleName = String.IsNullOrWhiteSpace(e.MiddleName) ? null : e.MiddleName,
                            Surname = String.IsNullOrWhiteSpace(e.LastName) ? null : e.LastName,
                            EmailAddress = String.IsNullOrWhiteSpace(e.Email) ? null : e.Email,
                            VoiceTelephoneNumber = String.IsNullOrWhiteSpace(e.OfficePhone) ? null : e.OfficePhone,
                            SamAccountName = e.UpnUsername.Substring(0, e.UpnUsername.IndexOf('@')),
                            UserPrincipalName = e.UpnUsername,
                            Enabled = enabled
                        };

                        up.SetPassword(password);
                        up.ExpirePasswordNow();
                        up.Save();

                        var d = (DirectoryEntry)up.GetUnderlyingObject();

                        SetProperty(d, "wWWHomePage", e.Website);
                        SetProperty(d, "title", e.JobTitle);
                        SetProperty(d, "physicalDeliveryOfficeName", e.Office);
                        SetProperty(d, "company", e.Company);
                        SetProperty(d, "department", e.Department);
                        SetProperty(d, "employeeID", e.BadgeId);
                        SetProperty(d, "employeeNumber", e.EmployeeId);
                        SetProperty(d, "manager", e.Manager != null ? e.Manager.DistinguishedName : null);
                        SetProperty(d, "streetAddress", e.Address1);
                        SetProperty(d, "postOfficeBox", e.Address2);
                        SetProperty(d, "l", e.City);
                        SetProperty(d, "postalCode", e.PostalCode);
                        SetProperty(d, "st", e.Province);
                        SetProperty(d, "c", e.Country);
                        SetProperty(d, "homephone", e.HomePhone);
                        SetProperty(d, "pager", e.Pager);
                        SetProperty(d, "mobile", e.MobilePhone);
                        SetProperty(d, "facsimileTelephoneNumber", e.Fax);
                        SetProperty(d, "ipPhone", e.SipPhone);

                        up.Save();

                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Adds the user to group.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public bool AddUserToGroup(string username, string domain, string groupName)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(domain)) return false;
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain))
                {
                    try
                    {
                        var groupPrincipal = GroupPrincipal.FindByIdentity(context, IdentityType.Name, groupName);
                        if (groupPrincipal == null) return false;

                        //Adding the user to the group
                        groupPrincipal.Members.Add(context, IdentityType.UserPrincipalName, username);
                        groupPrincipal.Save();

                        return true;
                    }
                    catch (PrincipalExistsException)
                    {
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the user photo by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="domain">The domain.</param>
        /// <returns></returns>
        public byte[] GetUserPhotoByUsername(string username, string domain)
        {
            var e = (DirectoryEntry)GetUserPrincipalByUsername(username, domain).GetUnderlyingObject();
            return (byte[])e.Properties["jpegPhoto"].Value;
        }

        /// <summary>
        /// Clears the user photo.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="domain">The domain.</param>
        /// <returns></returns>
        public bool ClearUserPhoto(string username, string domain)
        {
            try
            {
                var u = GetUserPrincipalByUsername(username, domain);
                if (u != null)
                {
                    var e = (DirectoryEntry)u.GetUnderlyingObject();
                    SetProperty(e, "jpegPhoto", "");
                    e.CommitChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the user photo.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="photo">The photo.</param>
        /// <returns></returns>
        public bool UpdateUserPhoto(string username, string domain, byte[] photo)
        {
            try
            {
                var u = GetUserPrincipalByUsername(username, domain);

                if (u != null)
                {
                    var e = (DirectoryEntry)u.GetUnderlyingObject();
                    e.Properties["jpegPhoto"].Value = photo;
                    e.Properties["thumbnailPhoto"].Value = photo;
                    e.CommitChanges();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion //Public

        #region Metrics
        /// <summary>
        /// Gets the total user count.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns></returns>
        public int GetTotalUserCount(string domain)
        {
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain))
                {
                    try
                    {
                        // Create an in-memory user object to use as the query example.
                        var u = new UserPrincipal(context) { DisplayName = "*" };

                        // Run the query. The query locates users 
                        // that match the supplied user principal object. 
                        using (var ps = new PrincipalSearcher(u))
                        {
                            ps.QueryFilter = u;
                            return ps.FindAll().OfType<UserPrincipal>().Count();
                        }
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }


        /// <summary>
        /// Gets the total user count.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="locDn">The distinguished name.</param>
        /// <returns></returns>
        public int GetTotalUserCount(string domain, string locDn)
        {
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain, locDn))
                {
                    try
                    {
                        // Create an in-memory user object to use as the query example.
                        var u = new UserPrincipal(context) { DisplayName = "*" };

                        // Run the query. The query locates users 
                        // that match the supplied user principal object. 
                        using (var ps = new PrincipalSearcher(u))
                        {
                            ps.QueryFilter = u;
                            return ps.FindAll().OfType<UserPrincipal>().Count();
                        }
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets the expired account count.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="locDn">The distinguished name.</param>
        /// <returns></returns>
        public int GetExpiredAccountCount(string domain, string locDn)
        {
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain, locDn))
                {
                    try
                    {
                        var qUser = new UserPrincipal(context);
                        qUser.AdvancedSearchFilter.AccountExpirationDate(DateTime.Now, MatchType.LessThanOrEquals);

                        var s = new PrincipalSearcher(qUser);
                        return s.FindAll().OfType<UserPrincipal>().Where(l => l.UserPrincipalName != null && l.AccountExpirationDate != null).Count();
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets the expired password count.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="locDn">The distinguished name.</param>
        /// <returns></returns>
        public int GetExpiredPasswordCount(string domain, string locDn)
        {
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain, locDn))
                {
                    try
                    {
                        // Get Domain Policy
                        var maxPwdAge = new PasswordExpiration().Policy.MaxPasswordAge;
                        if (maxPwdAge == TimeSpan.MaxValue) return 0;

                        // Create query principal object
                        var qUser = new UserPrincipal(context);
                        qUser.AdvancedSearchFilter.LastPasswordSetTime(DateTime.Now.AddDays(-maxPwdAge.TotalDays),
                                                                        MatchType.GreaterThanOrEquals);

                        var s = new PrincipalSearcher(qUser);
                        return s.FindAll().OfType<UserPrincipal>().Where(l => l.UserPrincipalName != null).Count();
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }
        #endregion //Metrics

        #region Private

        private readonly string _connectionUsername;
        private readonly string _connectionPassword;

        /// <summary>
        /// Gets a principal context.
        /// </summary>
        /// <returns></returns>
        private PrincipalContext GetPrincipalContext(string domain)
        {
            return new PrincipalContext(ContextType.Domain,
                    domain,
                    null,
                    ContextOptions.Negotiate,
                    _connectionUsername,
                    _connectionPassword);
        }

        /// <summary>
        /// Gets the principal context.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="dn">The location to bind to (OU).</param>
        /// <returns></returns>
        private PrincipalContext GetPrincipalContext(string domain, string dn)
        {
            return new PrincipalContext(ContextType.Domain,
                    domain,
                    dn,
                    ContextOptions.Negotiate,
                    _connectionUsername,
                    _connectionPassword);
        }

        /// <summary>
        /// Gets the domain directory entry.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns></returns>
        [Obsolete("You should only use this method if the AccountManagement namespace will not work properly.", false)]
        private DirectoryEntry GetDomainDirectoryEntry(string domain)
        {
            return new DirectoryEntry("LDAP://" + domain, _connectionUsername, _connectionPassword);
        }

        /// <summary>
        /// Gets the name of the domain from the username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        private static string GetDomainNameFromUsername(string username)
        {
            if (username.Contains("@"))
            {
                var i = username.IndexOf("@") + 1;
                if (i > 0)
                    return username.Remove(0, i);
            }
            else
            {
                var i = username.IndexOf("\\");
                if (i >= 0)
                    return username.Remove(i);
            }
            return ConfigurationManager.ConnectionStrings["ADService"].ConnectionString.Substring(7).ToLower();
        }

        /// <summary>
        /// Builds the display name.
        /// </summary>
        /// <param name="f">The first name.</param>
        /// <param name="m">The middle name.</param>
        /// <param name="l">The last name.</param>
        /// <returns></returns>
        private static string BuildDisplayName(string f, string m, string l)
        {
            if (String.IsNullOrWhiteSpace(m))
                return f + " " + l;
            if (m.Length > 2)
                return f + " " + m.Remove(1) + ". " + l;
            return f + " " + m + ". " + l;
        }

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <param name="d">The directory entry to use.</param>
        /// <param name="p">The parameter to assign.</param>
        /// <param name="v">The value to use.</param>
        private static void SetProperty(DirectoryEntry d, string p, string v)
        {
            d.Properties[p].Value = String.IsNullOrWhiteSpace(v) ? null : v;
        }
        #endregion //Private
    }
}

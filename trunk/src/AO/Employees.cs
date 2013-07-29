namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Security;

    using THS.UMS.AD;
    using THS.UMS.DTO;
    using System.Security.Principal;

    public class Employees
    {
        #region Public

        /// <summary>
        /// Gets the employee by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public EmployeeDTO GetEmployeeByUsername(string username)
        {
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            return BuildEmployeeFromUserPrincipal(u.GetUserPrincipalByUsername(username, GetDomainNameFromUsername(username)));
        }

        /// <summary>
        /// Checks for existing username.
        /// </summary>
        /// <param name="f">The first name.</param>
        /// <param name="m">The middle name.</param>
        /// <param name="l">The last name.</param>
        /// <param name="locationId">The location id.</param>
        /// <returns></returns>
        public bool CheckForExistingUsername(string f, string m, string l, Guid locationId)
        {
            var loc = new Locations().GetLocation(locationId);
            return GetEmployeeByUsername(BuildUsernameFromName(f, m, l, loc)) != null;
        }

        /// <summary>
        /// Checks for existing username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public bool CheckForExistingUsername(string username)
        {
            return GetEmployeeByUsername(username) != null;
        }

        /// <summary>
        /// Builds the name of the username from.
        /// </summary>
        /// <param name="f">The f.</param>
        /// <param name="m">The m.</param>
        /// <param name="l">The l.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public string BuildUsernameFromName(string f, string m, string l, LocationDTO location)
        {
            // Get full and initials
            var first = f;
            var firstInitial = f.Substring(0, 1);

            var middle = "";
            var middleInitial = "";

            if (m != String.Empty || m.Length > 0)
            {
                middle = m;
                middleInitial = m.Substring(0, 1);
            }

            var last = l;
            var lastInitial = l.Substring(0, 1);

            var dic = new Dictionary<string, string>
                          {
                              {"$fname$", first},
                              {"$fi$", firstInitial},
                              {"$mname$", middle},
                              {"$mi$", middleInitial},
                              {"$lname$", last},
                              {"$li$", lastInitial}
                          };

            // Run the replacements against the template
            var re = new Regex(@"\$(\w+)\$", RegexOptions.Compiled);
            return (re.Replace(location.NewUsernameFormat, match => dic[match.Groups[0].Value]) + "@" + location.Directory).ToLower();
        }

        /// <summary>
        /// Builds the name of the username from.
        /// </summary>
        /// <param name="f">The f.</param>
        /// <param name="m">The m.</param>
        /// <param name="l">The l.</param>
        /// <param name="locationId">The location id.</param>
        /// <returns></returns>
        public string BuildUsernameFromName(string f, string m, string l, Guid locationId)
        {
            var location = new Locations().GetLocation(locationId);

            // Get full and initials
            var first = f;
            var firstInitial = f.Substring(0, 1);

            var middle = "";
            var middleInitial = "";

            if (m != String.Empty || m.Length > 0)
            {
                middle = m;
                middleInitial = m.Substring(0, 1);
            }

            var last = l;
            var lastInitial = l.Substring(0, 1);

            var dic = new Dictionary<string, string>
                          {
                              {"$fname$", first},
                              {"$fi$", firstInitial},
                              {"$mname$", middle},
                              {"$mi$", middleInitial},
                              {"$lname$", last},
                              {"$li$", lastInitial}
                          };

            // Run the replacements against the template
            var re = new Regex(@"\$(\w+)\$", RegexOptions.Compiled);
            return (re.Replace(location.NewUsernameFormat, match => dic[match.Groups[0].Value]) + "@" + location.Directory).ToLower();
        }

        /// <summary>
        /// Searches for an employee.
        /// </summary>
        /// <param name="query">The name to search for.</param>
        /// <returns></returns>
        public Dictionary<string, string> SearchForManagers(string query)
        {
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            var l = new Locations();
            return l.GetLocationSecurityGroup().SelectMany(g => u.SearchAllUsers(query, g.Key)).ToDictionary(e => e.DistinguishedName, e => GetSortName(e.GivenName, e.MiddleName, e.Surname));
        }

        /// <summary>
        /// Searches for employees.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public Dictionary<string, string> SearchForEmployees(string query)
        {
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            var l = new Locations();
            return l.GetLocationSecurityGroup().SelectMany(g => u.SearchAllUsers(query, g.Key)).ToDictionary(e => e.UserPrincipalName, e => GetSortName(e.GivenName, e.MiddleName, e.Surname));
        }

        /// <summary>
        /// Searches for employees and loads them.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public List<EmployeeDTO> SearchAndLoadEmployees(string query)
        {
            var result = new List<EmployeeDTO>();
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            var l = new Locations();
            foreach (var g in l.GetLocationSecurityGroup())
            {
                result.AddRange(u.SearchAllUsers(query, g.Key).Select(BuildEmployeeFromUserPrincipal));
            }
            return result;
        }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDTO> GetAllEmployees()
        {
            var emps = new List<EmployeeDTO>();
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            var l = new Locations();
            foreach (var g in l.GetLocationSecurityGroup())
            {
                var users = u.GetGroupUsers(g.Value, g.Key);
                foreach (var e in users)
                {
                    if (e == null) continue;

                    var emp = BuildEmployeeFromUserPrincipal(e);
                    if (!emps.Contains(emp) && !String.IsNullOrWhiteSpace(emp.Email))
                        emps.Add(emp);
                }
            }
            return emps.ToList();
        }

        /// <summary>
        /// Gets the location employees.
        /// </summary>
        /// <param name="id">The location id.</param>
        /// <returns></returns>
        public List<EmployeeDTO> GetLocationEmployees(Guid id)
        {
            if (id == Guid.Empty) return null;

            var l = new Locations().GetLocation(id);
            if (l == null) return null;

            return (from u in new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass")).GetGroupUsers(l.UmsDirectoryGroup, l.Directory)
                    where u != null
                    select BuildEmployeeFromUserPrincipal(u)).OrderBy(e => e.SortName).ToList();
        }

        /// <summary>
        /// Changes the employee password.
        /// </summary>
        /// <param name="newPassword">The new password.</param>
        /// <param name="confPassword">The conf password.</param>
        /// <returns></returns>
        public bool ChangeEmployeePassword(string username, string newPassword, bool expire)
        {


            try
            {
                var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
                var user = u.GetUserPrincipalByUsername(username);

                user.SetPassword(newPassword);
                if (expire == true)
                    user.ExpirePasswordNow();

                return true;
            }
            catch (PasswordException)
            {
                return false;
            }
        }

        /// <summary>
        /// Changes the employee password.
        /// </summary>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="confPassword">The conf password.</param>
        /// <returns></returns>
        public bool ChangeEmployeePassword(string oldPassword, string newPassword, string confPassword)
        {
            if (newPassword == confPassword)
            {
                try
                {
                    var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
                    var user = u.GetUserPrincipalByUsername(HttpContext.Current.User.Identity.Name);

                    user.ChangePassword(oldPassword, newPassword);

                    return true;
                }
                catch (PasswordException)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="e">The employee to update.</param>
        /// <returns></returns>
        public bool UpdateEmployee(EmployeeDTO e)
        {
            if (e != null)
            {
                // Validate the names
                if (String.IsNullOrWhiteSpace(e.FirstName))
                    return false;

                if (String.IsNullOrWhiteSpace(e.LastName))
                    return false;

                // Get Current record
                var old = GetEmployeeByUsername(e.UpnUsername);

                // Update the record
                var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
                var retVal = u.UpdateUserPrincipalByEmployee(e, GetDomainNameFromUsername(e.UpnUsername));

                // Add Audit Log
                if (new AuditLog().SaveAuditLog(old, e))
                    return retVal;
            }
            return false;
        }

        /// <summary>
        /// Gets the employee photo.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="thumb">if set to <c>true</c> a thumbnail will be generated.</param>
        /// <returns></returns>
        public byte[] GetEmployeePhoto(string username, bool thumb)
        {
            // Get the photo bytes
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            var p = u.GetUserPhotoByUsername(username, GetDomainNameFromUsername(username));

            // Declare needed variables
            Image i;

            // Check for valid photos
            if (p == null)
            {
                // No image, load the default
                i = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/No-Photo.png"));
            }
            else
            {
                // Capture the photo stream
                using (var photoStream = new MemoryStream(p))
                {
                    i = Image.FromStream(photoStream);

                    // Resize if needed
                    if (thumb)
                    {
                        const int width = 96;
                        var ratio = (decimal)width / i.Width;
                        var height = Convert.ToInt32(i.Height * ratio);

                        // Resize the image
                        var imgCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        i = i.GetThumbnailImage(width, height, imgCallback, IntPtr.Zero);
                    }
                }
            }

            // Return the image
            using (var ms = new MemoryStream())
            {
                i.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// A callback method for the thumbnail generation
        /// </summary>
        /// <returns></returns>
        public bool ThumbnailCallback()
        {
            return false;
        }

        /// <summary>
        /// Clears the employee photo.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public bool ClearEmployeePhoto(string username)
        {
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            return u.ClearUserPhoto(username, GetDomainNameFromUsername(username));
        }

        /// <summary>
        /// Updates the employee photo.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="photo">The photo.</param>
        /// <returns></returns>
        public bool UpdateEmployeePhoto(string username, byte[] photo)
        {
            if (photo != null)
            {
                try
                {
                    // Manipulate the image
                    using (var ms = new MemoryStream(photo))
                    using (var msSave = new MemoryStream())
                    {
                        // Get the image
                        var i = Image.FromStream(ms);

                        // Resize the image
                        const int width = 128;
                        var ratio = (decimal)width / i.Width;
                        var height = Convert.ToInt32(i.Height * ratio);

                        var imgCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        i = i.GetThumbnailImage(width, height, imgCallback, IntPtr.Zero);

                        // Save the photo
                        i.Save(msSave, ImageFormat.Png);
                        var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
                        return u.UpdateUserPhoto(username, GetDomainNameFromUsername(username), msSave.ToArray());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("UpdateEmployeePhoto from string and byte array", ex);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Updates the employee photo.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="path">The path to the photo.</param>
        /// <returns></returns>
        public bool UpdateEmployeePhoto(string username, string path)
        {
            if (path != null)
            {
                try
                {
                    // Manipulate the image
                    using (var msSave = new MemoryStream())
                    {
                        // Get the image
                        var i = Image.FromFile(HttpContext.Current.Server.MapPath(path));

                        // Resize the image
                        const int width = 128;
                        var ratio = (decimal)width / i.Width;
                        var height = Convert.ToInt32(i.Height * ratio);

                        var imgCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        i = i.GetThumbnailImage(width, height, imgCallback, IntPtr.Zero);

                        // Save the photo
                        i.Save(msSave, ImageFormat.Png);
                        var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
                        return u.UpdateUserPhoto(username, GetDomainNameFromUsername(username), msSave.ToArray());
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="emp">The employee to add.</param>
        /// <param name="locationId">The location Id to use.</param>
        /// <param name="password">The password to use.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="notifyEmail">The new account notification email.</param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeDTO emp, Guid locationId, string password, bool enabled, string notifyEmail)
        {
            if (String.IsNullOrWhiteSpace(password))
                password = Membership.GeneratePassword(8, 2);

            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));

            // Get location
            var l = new Locations().GetLocation(locationId);

            // Add employee to AD
            if (!u.AddUserPrincipalByEmployee(emp, l, password, enabled)) return false;

            // Add Audit Log
            new AuditLog().SaveAuditLog(new EmployeeDTO(), emp);

            // Add employee to Location Group)
            if (!u.AddUserToGroup(emp.UpnUsername, GetDomainNameFromUsername(emp.UpnUsername), l.UmsDirectoryGroup))
                return false;

            // Send e-mail with information
            var mail = new Emails();
            var msg = new EmailDTO
            {
                Address = notifyEmail,
                EffectiveDate = DateTime.UtcNow,
                Subject = "New Account Created"
            };

            var e = GetEmployeeByUsername(emp.UpnUsername);
            var d = EmailReplacements.GetReplacementDictionary(e);
            d.Add("$title$", AppSettings.GetValue("AppTitle"));
            d.Add("$link$", AppSettings.GetValue("AppUrl"));
            d.Add("$password$", password);
            d.Add("$ntdomain$", l.DirectoryNt);

            var t = mail.GetEmailTemplate(msg.Subject).Body;
            msg.Body = EmailReplacements.ReplaceTemplateWithDictionary(t, d);

            mail.AddEmail(msg);

            // Send it to the user if they have an e-amil
            if (!String.IsNullOrWhiteSpace(e.Email))
            {
                msg.Address = e.Email;
                mail.AddEmail(msg);
            }


            return true;
        }

        /// <summary>
        /// Gets the group members.
        /// </summary>
        /// <param name="group">The group to get.</param>
        /// <returns></returns>
        public List<EmployeeDTO> GetGroupMembers(string group)
        {
            var ret = new List<EmployeeDTO>();
            var usrPrinc = new List<UserPrincipal>();
            var g = new Groups(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            foreach (var i in g.GetMembersOfGroup(group))
            {
                ret.Add(BuildEmployeeFromUserPrincipal(i));
            }
            return ret;
        }

        /// <summary>
        /// Enables a User Account.
        /// </summary>
        /// <param name="username">The users UPNUsername.</param>
        /// <returns></returns>
        public bool EnableEmployee(string username)
        {
            try
            {
                var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
                var userPrinc = u.GetUserPrincipalByUsername(username, GetDomainNameFromUsername(username));
                userPrinc.Enabled = true;
                userPrinc.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Disables a User Account.
        /// </summary>
        /// <param name="username">The users UPNUsername.</param>
        /// <returns></returns>
        public bool DisableEmployee(string username)
        {
            try
            {
                var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
                var userPrinc = u.GetUserPrincipalByUsername(username, GetDomainNameFromUsername(username));
                userPrinc.Enabled = false;
                userPrinc.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Unlocks a User Account.
        /// </summary>
        /// <param name="username">The users UPNUsername.</param>
        /// <returns></returns>
        public bool UnlockEmployee(string username)
        {
            try
            {
                var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
                var userPrinc = u.GetUserPrincipalByUsername(username, GetDomainNameFromUsername(username));
                userPrinc.UnlockAccount();
                userPrinc.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Private
        /// <summary>
        /// Builds the employee from user principal.
        /// </summary>
        /// <param name="u">The u.</param>
        /// <returns></returns>
        private EmployeeDTO BuildEmployeeFromUserPrincipal(UserPrincipal u)
        {
            if (u != null)
            {
                var e = (DirectoryEntry)u.GetUnderlyingObject();
                var p = new PasswordExpiration();

                var emp = new EmployeeDTO
                {
                    DisplayName = u.DisplayName,
                    SortName = String.IsNullOrWhiteSpace(u.MiddleName)
                                  ? GetSortName(u.GivenName, GetProperty(e, "initials"), u.Surname)
                                  : GetSortName(u.GivenName, u.MiddleName, u.Surname),
                    FirstName = u.GivenName,
                    MiddleName = u.MiddleName,
                    LastName = u.Surname,
                    Email = u.EmailAddress,
                    Website = GetProperty(e, "wWWHomePage"),
                    JobTitle = GetProperty(e, "title"),
                    Office = GetProperty(e, "physicalDeliveryOfficeName"),
                    Company = GetProperty(e, "company"),
                    Department = GetProperty(e, "department"),
                    BadgeId = GetProperty(e, "employeeID"),
                    EmployeeId = GetProperty(e, "employeeNumber"),
                    Manager = GetProperty(e, "manager") != GetProperty(e, "distinguishedName")
                                  ? GetEmployeeByUsername(GetProperty(e, "manager"))
                                  : null,
                    Address1 = GetProperty(e, "streetAddress"),
                    Address2 = GetProperty(e, "postOfficeBox"),
                    City = GetProperty(e, "l"),
                    PostalCode = GetProperty(e, "postalCode"),
                    Province = GetProperty(e, "st"),
                    Country = GetProperty(e, "c"),
                    HomePhone = GetProperty(e, "homephone"),
                    OfficePhone = u.VoiceTelephoneNumber,
                    Pager = GetProperty(e, "pager"),
                    MobilePhone = GetProperty(e, "mobile"),
                    Fax = GetProperty(e, "facsimileTelephoneNumber"),
                    SipPhone = GetProperty(e, "ipPhone"),
                    Username = u.SamAccountName.ToLower(),
                    UpnUsername = !String.IsNullOrWhiteSpace(u.UserPrincipalName) ? u.UserPrincipalName.ToLower() : u.SamAccountName.ToLower(),
                    DistinguishedName = GetProperty(e, "distinguishedName"),
                    AccountStatus = GetProperty(e, ""),
                    Notes = GetProperty(e, "info"),
                    AccountLocked = u.AccountLockoutTime.HasValue ? true : false,
                    AccountDisabled = u.Enabled.HasValue ? u.Enabled.Value ? false : true : false,
                    AccountExpired = u.AccountExpirationDate.HasValue ? true : false,
                    AccountExpDate = u.AccountExpirationDate.HasValue
                                         ? u.AccountExpirationDate.Value
                                         : DateTime.MaxValue,
                    PasswordExpDate = p.GetExpiration(e)
                };

                return emp;
            }
            return null;
        }

        /// <summary>
        /// Gets the domain name from username.
        /// </summary>
        /// <param name="u">The username.</param>
        /// <returns></returns>
        private static string GetDomainNameFromUsername(string u)
        {
            if (u == null) return null;

            // Check for UPN
            if (u.Contains("@"))
                u = new WindowsIdentity(u).Name;
                //return u.Substring(u.IndexOf("@") + 1);

            // Check for Distinguished Path
            var d = "";
            if (u.Contains("DC="))
            {
                var dn = u.Split(',');
                var cnt = 0;
                foreach (var p in dn)
                {
                    cnt += 1;
                    if (p.Contains("DC="))
                    {
                        d += p.Substring(3);
                        d += cnt != dn.Count() ? "." : "";
                    }
                }
                return d;
            }

            // Windows NT Style
            var i = u.IndexOf('\\');
            if (i != -1)
                d = u.Substring(0, u.IndexOf('\\'));
            else
                throw new ApplicationException("The username is not in a proper format.  Ensure it is either a NT or UPN style username.");

            // Validate directory
            var l = new Locations();
            var dom = l.GetDirectoryByNtDirectory(d);

            return dom;
        }

        /// <summary>
        /// Gets the full name in a sort friendly fashion
        /// </summary>
        /// <param name="f">The first name.</param>
        /// <param name="m">The middle name.</param>
        /// <param name="l">The last name.</param>
        /// <returns></returns>
        private static string GetSortName(string f, string m, string l)
        {
            if (String.IsNullOrWhiteSpace(m))
                return l + ", " + f;
            if (m.Length > 2)
                return l + ", " + f + " " + m.Remove(1) + ".";
            return l + ", " + f + " " + m + ".";
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="d">The directory entry to use.</param>
        /// <param name="p">The parameter to get.</param>
        /// <returns></returns>
        private static string GetProperty(DirectoryEntry d, string p)
        {
            var v = d.Properties[p].Value;

            return v != null ? v.ToString() : null;
        }

        #endregion
    }
}

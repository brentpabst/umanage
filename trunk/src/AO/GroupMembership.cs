namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;
    using System.Text.RegularExpressions;

    using THS.UMS.AD;
    using THS.UMS.DTO;

    public class GroupMembership
    {
        #region Public

        public List<GroupsDTO> ReturnAllGroups()
        {
            var ret = new List<GroupsDTO>();
            var g = new Groups(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"), GetIgnoreList());
            var grpList = g.GetAllGroups();
            foreach (var i in grpList)
            {
                ret.Add(BuildGroupFromGroupPrincipal(i));
            }

            return ret;
        }

        public List<GroupsDTO> SearchAndLoadGroups(string query)
        {
            var ret = new List<GroupsDTO>();
            var g = new Groups(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"), GetIgnoreList());
            var grpList = g.SearchAllGroups(query);
            foreach (var i in grpList)
            {
                ret.Add(BuildGroupFromGroupPrincipal(i));
            }

            return ret;
        }

        public GroupsDTO GetGroupByName(string name)
        {
            var ret = new GroupsDTO();
            var g = new Groups(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            var grp = g.GetGroup(name);

            ret = BuildGroupFromGroupPrincipal(grp);
            return ret;
        }

        /// <summary>
        /// Returns a list of groups a user is a MemberOf.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public List<GroupsDTO> GetGroupsForUser(string user)
        {
            var ret = new List<GroupsDTO>();
            var g = new Groups(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"), GetIgnoreList());

            string domain = GetDomainNameFromUsername(user);
            var grpList = g.MemberOf(user, domain);
            foreach (var i in grpList)
            {
                ret.Add(BuildGroupFromGroupPrincipal(i));
            }

            return ret;

        }

        public bool RemoveUserFromGroup(string username, string group)
        {
            if (String.IsNullOrWhiteSpace(username))
                return false;
            //We need the Distinguished names
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            var g = new Groups(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));

            var user = u.GetUserPrincipalByUsername(username);
            string domain = GetDomainNameFromUsername(username);

            return g.RemoveUserfromGroup(user.DistinguishedName, domain, group);
        }

        public bool AddUserToGroup(string username, string group)
        {
            if (String.IsNullOrWhiteSpace(username))
                return false;
            //We need the Distinguished names
            var u = new Users(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            var g = new Groups(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));

            var user = u.GetUserPrincipalByUsername(username);
            string domain = GetDomainNameFromUsername(username);

            return g.AddUserToGroup(user.DistinguishedName, domain, group);
        }

        public bool UpdateGroupManager(string username, string group)
        {
            if (String.IsNullOrWhiteSpace(username))
                return false;
            var g = new Groups(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));

            return g.GroupManagedBy(username, GetDomainNameFromUsername(username), group);
        }

        public bool UpdateGroupDescription(string group, string desc)
        {
            var g = new Groups(AppSettings.GetValue("AdUser"), AppSettings.GetValue("AdUserPass"));
            return g.UpdateGroupDescription(GetDomainNameFromUsername(UserPrincipal.Current.UserPrincipalName), group, desc);
        }

        #endregion

        #region Private

        /// <summary>
        /// Builds the group from GroupPrincipal.
        /// </summary>
        /// <param name="g">The group.</param>
        /// <returns></returns>
        /// 
        private GroupsDTO BuildGroupFromGroupPrincipal(GroupPrincipal g)
        {
            if (g != null)
            {
                var e = (DirectoryEntry)g.GetUnderlyingObject();
                // TODO Add all needed elements from GroupPrincipal, some are null though and need to be handled
                var grp = new GroupsDTO
                {
                    DisplayName = GetProperty(e, "DisplayName"),
                    Name = removerContainer(e.Name),
                    DistinguishedName = GetProperty(e, "DistinguishedName"),
                    Description = GetProperty(e, "Description"),
                    LDAPPath = e.Path,
                    groupGuid = e.Guid,
                    isSecurityGroup = (bool)g.IsSecurityGroup,
                    ManagedBy = GetProperty(e, "managedBy")

                };

                return grp;
            }
            return null;
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


        private string removerContainer(string groupName)
        {
            return Regex.Replace(groupName, "CN=", String.Empty);
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
                return u.Substring(u.IndexOf("@") + 1);

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

        private List<string> GetIgnoreList()
        {
            List<string> ignorelist = new List<string>(AppSettings.GetValue("groupstoignore").Split(','));
            return ignorelist;

        }



        #endregion
    }
}

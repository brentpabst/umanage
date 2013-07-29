namespace THS.UMS.AD
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;

    public class Groups
    {
        #region Constructor

        ///<summary>
        /// Constructor for the Groups Class
        ///</summary>
        ///<param name="user">AD Username</param>
        ///<param name="pass">AD Password</param>
        ///<returns>Nothing</returns>
        ///<remarks></remarks>
        public Groups(string user, string pass)
        {
            _connectionUsername = user;
            _connectionPassword = pass;

        }

        ///<summary>
        /// Constructor for the Groups Class
        ///</summary>
        ///<param name="user">AD Username</param>
        ///<param name="pass">AD Password</param>
        ///<param name="ignore">List of groups to ignore</param>
        ///<returns>Nothing</returns>
        ///<remarks></remarks>
        public Groups(string user, string pass, List<string> ignore)
        {
            _connectionUsername = user;
            _connectionPassword = pass;

            _defaultGroupsToIgnore.AddRange(ignore);
        }

        #endregion

        #region Ignore Lists
        // IMPORTANT - DEFAULT LIST OF ACTIVE DIRECTORY USERS TO "IGNORE"
        //             DO NOT REMOVE ANY OF THESE UNLESS YOU FULLY UNDERSTAND THE SECURITY IMPLICATIONS
        //             VERYIFY THAT ALL CRITICAL USERS ARE IGNORED DURING TESTING
        private List<string> _DefaultUsersToIgnore = new List<string>
        {
            "Administrator", "TsInternetUser", "Guest", "krbtgt", "Replicate", "SERVICE", "SMSService"
        };

        // IMPORTANT - DEFAULT LIST OF ACTIVE DIRECTORY DOMAIN GROUPS TO "IGNORE"
        //             PREVENTS ENUMERATION OF CRITICAL DOMAIN GROUP MEMBERSHIP
        //             DO NOT REMOVE ANY OF THESE UNLESS YOU FULLY UNDERSTAND THE SECURITY IMPLICATIONS
        //             VERIFY THAT ALL CRITICAL GROUPS ARE IGNORED DURING TESTING BY CALLING GetAllRoles MANUALLY
        private List<string> _defaultGroupsToIgnore = new List<string>
        {
            "Domain Guests", "Domain Computers", "Group Policy Creator Owners", "Guests", "Users",
            "Domain Users", "Pre-Windows 2000 Compatible Access", "Exchange Domain Servers", "Schema Admins",
            "Enterprise Admins", "Domain Admins", "Cert Publishers", "Backup Operators", "Account Operators",
            "Server Operators", "Print Operators", "Replicator", "Domain Controllers", "WINS Users",
            "DnsAdmins", "DnsUpdateProxy", "DHCP Users", "DHCP Administrators", "Exchange Services",
            "Exchange Enterprise Servers", "Remote Desktop Users", "Network Configuration Operators",
            "Incoming Forest Trust Builders", "Performance Monitor Users", "Performance Log Users",
            "Windows Authorization Access Group", "Terminal Server License Servers", "Distributed COM Users",
            "Administrators", "Everybody", "RAS and IAS Servers", "MTS Trusted Impersonators",
            "MTS Impersonators", "Everyone", "LOCAL", "Authenticated Users", "IIS_IUSRS",
            "Cryptographic Operators", "Event Log Readers", "Certificate Service DCOM Access", 
            "Allowed RODC Password Replication Group", "Denied RODC Password Replication Group", 
            "Enterprise Read-only Domain Controllers", "Read-only Domain Controllers"
        };

        #endregion

        #region Public

        ///<summary>
        /// Searches the local domain for all group principals
        ///</summary>
        ///<returns>A list of group principals if successful; otherwise null</returns>
        ///<remarks>This method uses objects that are new in version 3 of the .Net Framework</remarks>
        public List<GroupPrincipal> GetAllGroups()
        {
            List<GroupPrincipal> retSearch = null;
            List<GroupPrincipal> retVal = new List<GroupPrincipal>();

            //Create a context for the search take place in
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                //Create a group principal filter with the context
                using (GroupPrincipal filter = new GroupPrincipal(context))
                {
                    //Create a principal search using the filter
                    using (PrincipalSearcher searcher = new PrincipalSearcher(filter))
                    {
                        //Execute a search with the searcher using the filter against the context of the local domain.
                        //searcher.FindAll is called in a LINQ expression to provide the collection of GroupPrincipals.
                        //The LINQ expression wrapped in parents to define scope and followed by a call to ToList which
                        //will convert the IEnumerable returned by the LINQ expression into a generic List<GroupPrincipal>
                        retSearch = (from principal in searcher.FindAll() select principal as GroupPrincipal).ToList();
                        //Exclude ignoreList
                        foreach (var group in retSearch)
                        {
                            if (_defaultGroupsToIgnore.Contains(group.Name) == false)
                                retVal.Add(group);
                        }
                    }
                }
            }
            return retVal;
        }

        ///<summary>
        /// Searches the local domain for group principals based on a query filter
        ///</summary>
        ///<returns>A list of group principals if successful; otherwise null</returns>
        ///<remarks>This method uses objects that are new in version 3 of the .Net Framework</remarks>
        public List<GroupPrincipal> SearchAllGroups(string query)
        {
            List<GroupPrincipal> retSearch = null;
            List<GroupPrincipal> retVal = new List<GroupPrincipal>();

            //Create a context for the search take place in
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                //Create a group principal filter with the context
                using (GroupPrincipal filter = new GroupPrincipal(context) { Name = "*" + query + "*" })
                {
                    //Create a principal search using the filter
                    using (PrincipalSearcher searcher = new PrincipalSearcher(filter))
                    {
                        //Execute a search with the searcher using the filter against the context of the local domain.
                        //searcher.FindAll is called in a LINQ expression to provide the collection of GroupPrincipals.
                        //The LINQ expression wrapped in parents to define scope and followed by a call to ToList which
                        //will convert the IEnumerable returned by the LINQ expression into a generic List<GroupPrincipal>
                        searcher.QueryFilter = filter;
                        retSearch = (from principal in searcher.FindAll() select principal as GroupPrincipal).ToList();
                        //Exclude ignoreList
                        foreach (var group in retSearch)
                        {
                            if (_defaultGroupsToIgnore.Contains(group.Name) == false)
                                retVal.Add(group);
                        }
                    }
                }
            }
            return retVal;
        }


        public GroupPrincipal GetGroup(string sGroupName)
        {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain);

            GroupPrincipal oGroupPrincipal = GroupPrincipal.FindByIdentity(oPrincipalContext, sGroupName);
            return oGroupPrincipal;
        }

        /// <summary>
        /// Returns a list of users in a group.
        /// </summary>
        /// <param name="group">The group</param>
        /// <returns></returns>
        public List<UserPrincipal> GetMembersOfGroup(string group)
        {
            if (String.IsNullOrWhiteSpace(group)) return null;
            if (String.IsNullOrWhiteSpace(_connectionUsername) && String.IsNullOrWhiteSpace(_connectionPassword)) return null;

            var ctx = new PrincipalContext(ContextType.Domain);
            Users u = new Users(_connectionUsername, _connectionPassword);

            var g = GroupPrincipal.FindByIdentity(ctx, group);
            if (g == null) return null;

            return g.GetMembers(false).OfType<UserPrincipal>().Select(p => u.GetUserPrincipalByUsername(p.UserPrincipalName)).ToList();
        }

        /// <summary>
        /// Add a user to the specified group.
        /// </summary>
        /// <param name="username">The username to add</param>
        /// <param name="domain">The domain to use</param>
        /// <param name="groupName">The group to add to</param>
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
                        var groupPrincipal = GroupPrincipal.FindByIdentity(context, groupName);
                        var userPrincipal = UserPrincipal.FindByIdentity(context, username);
                        if (groupPrincipal != null && userPrincipal != null)
                        {
                            groupPrincipal.Members.Add(userPrincipal);
                            groupPrincipal.Save();

                            return true;
                        }
                        return false;
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
        /// Removes a user from a group.
        /// </summary>
        /// <param name="username">The username to remove</param>
        /// <param name="domain">The domain to open</param>
        /// <param name="groupName">The group to remove from</param>
        /// <returns></returns>
        public bool RemoveUserfromGroup(string username, string domain, string groupName)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(domain)) return false;
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain))
                {
                    try
                    {
                        var groupPrincipal = GroupPrincipal.FindByIdentity(context, groupName);
                        var userPrincipal = UserPrincipal.FindByIdentity(context, username);
                        if (groupPrincipal != null && userPrincipal != null)
                        {
                            //Remove the user from the group
                            groupPrincipal.Members.Remove(userPrincipal);
                            groupPrincipal.Save();
                            return true;
                        }
                        return false;
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
        /// Set the ManagedBy Property of a group.
        /// </summary>
        /// <param name="username">The username of the manager to set</param>
        /// <param name="domain">The domain to use</param>
        /// <param name="groupName">The group to update</param>
        /// <returns></returns>
        public bool GroupManagedBy(string username, string domain, string groupName)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(domain)) return false;
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain))
                {
                    try
                    {
                        var groupPrincipal = GroupPrincipal.FindByIdentity(context, groupName);
                        var userPrincipal = UserPrincipal.FindByIdentity(context, username);
                        if (groupPrincipal != null && userPrincipal != null)
                        {
                            var d = groupPrincipal.GetUnderlyingObject() as DirectoryEntry;

                            SetProperty(d, "managedBy", userPrincipal.DistinguishedName);

                            d.CommitChanges();
                            groupPrincipal.Save();

                            return true;
                        }
                        return false;
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
        /// Set the Description Property of a group.
        /// </summary>
        /// <param name="domain">The domain to use</param>
        /// <param name="groupName">The group to update</param>
        /// <param name="description">The description to set</param>
        /// <returns></returns>
        public bool UpdateGroupDescription(string domain, string groupName, string description)
        {
            if (String.IsNullOrWhiteSpace(domain)) return false;
            if (!String.IsNullOrWhiteSpace(_connectionUsername) && !String.IsNullOrWhiteSpace(_connectionPassword))
            {
                using (var context = GetPrincipalContext(domain))
                {
                    try
                    {
                        var groupPrincipal = GroupPrincipal.FindByIdentity(context, groupName);
                        if (groupPrincipal != null)
                        {
                            groupPrincipal.Description = description;
                            groupPrincipal.Save();
                            return true;
                        }
                        return false;
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
        /// Returns a list of groups a user is a MemberOf.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="recursive">recurses into groups within groups</param>
        /// <returns></returns>
        public List<GroupPrincipal> MemberOf(string username, string domain)
        {
            List<GroupPrincipal> gList = new List<GroupPrincipal>();

            var ctx = GetPrincipalContext(domain);
            var u = UserPrincipal.FindByIdentity(ctx, username);
            if (u != null)
            {
                PrincipalSearchResult<Principal> groups = u.GetGroups();
                foreach (GroupPrincipal grp in groups)
                {
                    if (_defaultGroupsToIgnore.Contains(grp.Name) == false)
                        gList.Add(grp);
                }
            }
            return gList;
        }




        #endregion

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

        private GroupPrincipal GetGroup(string sGroupName, string domain)
        {
            PrincipalContext oPrincipalContext = GetPrincipalContext(domain);

            GroupPrincipal oGroupPrincipal = GroupPrincipal.FindByIdentity(oPrincipalContext, sGroupName);
            return oGroupPrincipal;
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

        #endregion
    }
}
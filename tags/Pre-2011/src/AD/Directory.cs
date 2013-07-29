using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System;

namespace PPI.UMS.AD
{
    /// <summary>
    /// Contains methods for interacting with Active Directory
    /// </summary>
    public class Directory
    {
        #region Public

        /// <summary>
        /// Verifies connection details against the specified domain name
        /// </summary>
        /// <param name="ldapAddress">The LDAP address to bind to the domain</param>
        /// <param name="Username">The username used to bind to the domain</param>
        /// <param name="Password">The password used to bind to the domain</param>
        /// <param name="ServerName">If successfully bound the domain controller that authorized the request</param>
        /// <returns><see cref="bool"/> Returns true if the details were verified</returns>
        public bool VerifyConnectionDetails(string ldapAddress, string Username, string Password, out string ServerName)
        {
            try
            {
                //Ensure we can connect to the domain
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, ldapAddress, null, ContextOptions.Negotiate, Username, Password))
                {

                    //See if the user specified has the needed permissions
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, Username);
                    user.UnlockAccount();

                    //If we get this far life is good
                    ServerName = context.ConnectedServer;
                    return true;
                }
            }
            catch
            {
                ServerName = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Verifies a user exists in the domain
        /// </summary>
        /// <param name="domain">The domain to verify against</param>
        /// <param name="username">The username users to bind to the domain</param>
        /// <param name="password">The password used to bind to the domain</param>
        /// <param name="userToVerify">The username to verify against the domain.</param>
        /// <returns><see cref="bool"/> Returns true if the user exists</returns>
        public bool VerifyUserExists(string domain, string username, string password, string userToVerify)
        {
            try
            {
                //Ensure we can connect to the domain
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain, null, ContextOptions.Negotiate, username, password))
                {

                    //See if the user specified has the needed permissions
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, userToVerify);

                    if (user != null)
                    {
                        //If we get this far life is good                    
                        return true;
                    }
                    else
                    {
                        //The user was null, most not exist
                        return false;
                    }
                }
            }
            catch
            {
                //Hit a wall, don't proceed.
                return false;
            }
        }

        /// <summary>
        /// Creates a blank user in the directory with the given username and password
        /// </summary>
        /// <param name="username">The username to use</param>
        /// <param name="password">The password to use</param>
        /// <returns>True if inserted</returns>
        public bool CreateNewUser(string username, string password, string displayName, out string retVal)
        {
            ProviderSettings ps = AD.Common.GetWebMembershipDetails();

            if (ps.Parameters.HasKeys())
            {
                PrincipalContext context = null;

                if (!String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["NewUserContainer"]))
                {
                    context = new PrincipalContext(ContextType.Domain, Common.GetDomainName(ConfigurationManager.ConnectionStrings["ADService"]), ConfigurationManager.AppSettings["NewUserContainer"], ContextOptions.Negotiate, ps.Parameters["connectionUsername"], ps.Parameters["connectionPassword"]);
                }
                else
                {
                    context = new PrincipalContext(ContextType.Domain, Common.GetDomainName(ConfigurationManager.ConnectionStrings["ADService"]), null, ContextOptions.Negotiate, ps.Parameters["connectionUsername"], ps.Parameters["connectionPassword"]);
                }

                using (context)
                {
                    // Check if user object already exists in the store
                    UserPrincipal usr = UserPrincipal.FindByIdentity(context, username);
                    if (usr != null)
                    {
                        retVal = "The user already exists, you cannot create a user with the same username. If this is a new employee you will need to contact an administrator to add this user manually they cannot be added with uManage.";
                        return false;
                    }
                    else
                    {
                        UserPrincipal userPrincipal = new UserPrincipal(context);
                        if (username != null && username.Length > 0)
                            userPrincipal.SamAccountName = username.ToLower();

                        userPrincipal.Name = displayName;
                        userPrincipal.SetPassword(password);
                        userPrincipal.Enabled = true;
                        userPrincipal.ExpirePasswordNow();

                        try
                        {
                            userPrincipal.Save();

                            GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(context, "uManage-Users");
                            if (groupPrincipal != null)
                            {
                                //check if user is already a member
                                if (!groupPrincipal.Members.Contains(context, IdentityType.SamAccountName, username))
                                {
                                    //Adding the user to the group
                                    groupPrincipal.Members.Add(userPrincipal);
                                    groupPrincipal.Save();
                                }
                            }
                            retVal = "";
                            return true;
                        }
                        catch
                        {
                            retVal = "There was an error while creating the account or adding it to the uManage security group.";
                            return false;
                        }
                    }
                }
            }
            else
            {
                retVal = "There was a problem getting the configuration values required.";
                return false;
            }
        }

        #endregion
    }
}

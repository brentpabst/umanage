using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data.Objects;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Hosting;
using System.Web.Security;
using PPI.UMS.BLL.Common;
using PPI.UMS.DAL;

namespace PPI.UMS.BLL
{
    public class UmsRoleProvider : RoleProvider
    {
        #region Members
        private const string EVENTSOURCE = "EFRoleProvider";
        private const string EVENTLOG = "Application";
        private const string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string connectionString;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name of the application to store and retrieve role information for.
        /// </summary>
        /// <returns>
        /// The name of the application to store and retrieve role information for.
        /// </returns>
        public override string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [write exceptions to event log].
        /// </summary>
        /// <value><c>true</c> if [write exceptions to event log]; otherwise, <c>false</c>.
        /// </value>
        public bool WriteExceptionsToEventLog { get; set; }
        #endregion

        #region Public
        /// <summary>
        /// System.Configuration.Provider.ProviderBase.Initialize Method
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The name of the provider is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The name of the provider has a length of zero.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"/> on a provider after the provider has already been initialized.
        /// </exception>
        public override void Initialize(string name, NameValueCollection config)
        {
            // Initialize values from web.config.
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if (String.IsNullOrEmpty(name))
            {
                name = "EFRoleProvider";
            }

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Smart-Soft EF Role Provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            ApplicationName = (string)ProviderUtils.GetConfigValue(config, "applicationName", HostingEnvironment.ApplicationVirtualPath);
            WriteExceptionsToEventLog = (bool)ProviderUtils.GetConfigValue(config, "writeExceptionsToEventLog", false);

            // Read connection string.
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            if (connectionStringSettings == null || connectionStringSettings.ConnectionString.Trim() == string.Empty)
            {
                throw new ProviderException("Connection string cannot be blank.");
            }

            connectionString = connectionStringSettings.ConnectionString;
        }

        /// <summary>
        /// Gets a value indicating whether the specified user is in the specified role for the configured applicationName.
        /// </summary>
        /// <param name="username">The user name to search for.</param>
        /// <param name="roleName">The role to search in.</param>
        /// <returns>true if the specified user is in the specified role for the configured applicationName; otherwise, false.</returns>
        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                using (uManageEntities context = new uManageEntities(connectionString))
                {
                    return (from u in context.Users
                            where u.UserName == username && u.Application.Name == ApplicationName
                            from r in u.Roles
                            where r.Name == roleName && r.Application.Name == ApplicationName
                            select r).Count() > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a list of the roles that a specified user is in for the configured applicationName.
        /// </summary>
        /// <param name="username">The user to return a list of roles for.</param>
        /// <returns>A string array containing the names of all the roles that the specified user is in for the configured applicationName.</returns>
        public override string[] GetRolesForUser(string username)
        {
            using (uManageEntities context = new uManageEntities(connectionString))
            {
                return (from u in context.Users
                        where u.UserName == username && u.Application.Name == ApplicationName
                        from r in u.Roles
                        where r.Application.Name == ApplicationName
                        select r.Name).ToArray();
            }
        }

        /// <summary>
        /// Adds a new role to the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to create.</param>
        public override void CreateRole(string roleName)
        {
            // Validate role name
            if (roleName.Contains(","))
            {
                throw new ArgumentException("Role names cannot contain commas.");
            }

            if (RoleExists(roleName))
            {
                throw new ProviderException("Role name already exists.");
            }

            try
            {
                using (uManageEntities context = new uManageEntities(connectionString))
                {
                    Application application = ProviderUtils.EnsureApplication(ApplicationName, context);

                    // Create new role
                    Role newRole = new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = roleName,
                        Application = application
                    };
                    context.AddToRoles(newRole);
                    context.SaveChanges();
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Removes a role from the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to delete.</param>
        /// <param name="throwOnPopulatedRole">If true, throw an exception if <paramref name="roleName"/> has one or more members and do not delete <paramref name="roleName"/>.</param>
        /// <returns>
        /// true if the role was successfully deleted; otherwise, false.
        /// </returns>
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            // Validate role
            if (!RoleExists(roleName))
            {
                throw new ProviderException("Role does not exist.");
            }

            if (throwOnPopulatedRole && GetUsersInRole(roleName).Length > 0)
            {
                throw new ProviderException("Cannot delete a populated role.");
            }

            using (uManageEntities context = new uManageEntities(connectionString))
            {
                Role role = GetRole(r => r.Name == roleName, context);
                if (role == null)
                {
                    return false;
                }

                try
                {
                    context.DeleteObject(role);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the specified role name already exists in the role data source for the configured applicationName.
        /// </summary>
        /// <returns>true if the role name already exists in the data source for the configured applicationName; otherwise, false.</returns>
        /// <param name="roleName">The name of the role to search for in the data source.</param>
        public override bool RoleExists(string roleName)
        {
            using (uManageEntities context = new uManageEntities(connectionString))
            {
                try
                {
                    return GetRole(r => r.Name == roleName, context) != null;
                }
                catch (ProviderException)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Adds the specified user names to the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="userNames">A string array of user names to be added to the specified roles.</param>
        /// <param name="roleNames">A string array of the role names to add the specified user names to.</param>
        public override void AddUsersToRoles(string[] userNames, string[] roleNames)
        {
            using (uManageEntities context = new uManageEntities(connectionString))
            {
                IQueryable<Role> roles = context.Roles.Where(MatchRoleApplication()).Where(ProviderUtils.BuildContainsExpression<Role, string>(r => r.Name, roleNames));
                if (roles.Count() != roleNames.Length)
                {
                    throw new ProviderException("Role not found.");
                }

                IQueryable<User> users = context.Users.Where(MatchUserApplication()).Where(ProviderUtils.BuildContainsExpression<User, string>(u => u.UserName, userNames));
                if (users.Count() != userNames.Length)
                {
                    foreach (string userid in userNames)
                    {
                        User user = new User();
                        user.Id = Guid.NewGuid();
                        user.LastActivityDate = DateTime.UtcNow;
                        user.UserName = userid;
                        user.LoweredUserName = userid.ToLower();
                        user.Application = ProviderUtils.EnsureApplication("uManage", context);
                        context.Users.AddObject(user);                        
                    }
                    context.SaveChanges();
                }

                try
                {
                    foreach (User user in users)
                    {
                        foreach (Role role in roles)
                        {
                            // Check whether user is already in role
                            if (IsUserInRole(user.UserName, role.Name))
                            {
                                throw new ProviderException(string.Format("User is already in role '{0}'.", role.Name));
                            }

                            user.Roles.Add(role);
                        }
                    }

                    context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                }
                catch
                {
                    return;
                }
                finally
                {
                    context.Connection.Close();
                }
            }
        }

        /// <summary>
        /// Removes the specified user names from the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="userNames">A string array of user names to be removed from the specified roles.</param>
        /// <param name="roleNames">A string array of role names to remove the specified user names from.</param>
        public override void RemoveUsersFromRoles(string[] userNames, string[] roleNames)
        {
            using (uManageEntities context = new uManageEntities(connectionString))
            {
                IQueryable<Role> roles = context.Roles.Where(MatchRoleApplication()).Where(ProviderUtils.BuildContainsExpression<Role, string>(r => r.Name, roleNames));
                if (roles.Count() != roleNames.Length)
                {
                    throw new ProviderException("Role not found.");
                }

                IQueryable<User> users = context.Users.Include("Roles").Where(MatchUserApplication()).Where(ProviderUtils.BuildContainsExpression<User, string>(u => u.UserName, userNames));
                if (users.Count() != userNames.Length)
                {
                    throw new ProviderException("User not found.");
                }

                try
                {
                    foreach (User user in users)
                    {
                        foreach (Role role in roles)
                        {
                            /*if (!user.Role.IsLoaded)
                            {
                                user.Role.Load();
                            }*/

                            if (user.Roles.Contains(role))
                            {
                                user.Roles.Remove(role);
                            }
                        }
                    }

                    context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                }
                catch
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Gets a list of users in the specified role for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to get the list of users for.</param>
        /// <returns>
        /// A string array containing the names of all the users who are members of the specified role for the configured applicationName.
        /// </returns>
        public override string[] GetUsersInRole(string roleName)
        {
            using (uManageEntities context = new uManageEntities(connectionString))
            {
                Role role = GetRole(r => r.Name == roleName, context);
                if (role == null)
                {
                    throw new ProviderException("Role not found.");
                }

                if (!role.Users.IsLoaded)
                {
                    role.Users.Load();
                }

                return role.Users.Select(u => u.UserName).ToArray();
            }
        }

        /// <summary>
        /// Gets a list of all the roles for the configured applicationName.
        /// </summary>
        /// <returns>A string array containing the names of all the roles stored in the data source for the configured applicationName.</returns>
        public override string[] GetAllRoles()
        {
            using (uManageEntities context = new uManageEntities(connectionString))
            {
                return context.Roles.Where(MatchRoleApplication()).Select(r => r.Name).ToArray();
            }
        }

        /// <summary>
        /// Gets an array of user names in a role where the user name contains the specified user name to match.
        /// </summary>
        /// <returns>A string array containing the names of all the users where the user name matches <paramref name="usernameToMatch" /> 
        /// and the user is a member of the specified role.</returns>
        /// <param name="roleName">The role to search in.</param>
        /// <param name="usernameToMatch">The user name to search for.</param>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            using (uManageEntities context = new uManageEntities(connectionString))
            {
                Role role = GetRole(r => r.Name == roleName, context);
                if (role == null)
                {
                    throw new ProviderException("Role not found.");
                }

                if (!role.Users.IsLoaded)
                {
                    role.Users.Load();
                }

                return role.Users.Select(u => u.UserName).Where(un => un.Contains(usernameToMatch)).ToArray();
            }
        }
        #endregion

        #region Private
        /// <summary>
        /// Get role from database. Throws an error if the role could not be found.
        /// </summary>
        /// <param name="query">The role query.</param>
        /// <param name="context">The context.</param>
        /// <returns>Found role entity.</returns>
        private Role GetRole(Expression<Func<Role, bool>> query, uManageEntities context)
        {
            Role role = context.Roles.Where(query).Where(MatchRoleApplication()).FirstOrDefault();
            if (role == null)
            {
                throw new ProviderException("The supplied role name could not be found.");
            }

            return role;
        }

        /// <summary>
        /// Matches the local application name.
        /// </summary>
        /// <returns>Status whether passed in user matches the application.</returns>
        private Expression<Func<Role, bool>> MatchRoleApplication()
        {
            return role => role.Application.Name == ApplicationName;
        }

        /// <summary>
        /// Matches the local application name.
        /// </summary>
        /// <returns>Status whether passed in user matches the application.</returns>
        private Expression<Func<User, bool>> MatchUserApplication()
        {
            return user => user.Application.Name == ApplicationName;
        }

        #endregion
    }
}

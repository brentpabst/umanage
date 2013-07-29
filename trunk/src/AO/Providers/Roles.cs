namespace THS.UMS.AO.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration.Provider;
    using System.Data.Objects;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Security;

    using THS.UMS.DTO;
    using THS.UMS.EF;

    public class Roles : RoleProvider
    {
        /// <summary>
        /// Gets a value indicating whether the specified user is in the specified role for the configured applicationName.
        /// </summary>
        /// <returns>
        /// true if the specified user is in the specified role for the configured applicationName; otherwise, false.
        /// </returns>
        /// <param name="username">The user name to search for.</param><param name="roleName">The role to search in.</param>
        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                using (var ctx = new AppEntities())
                {
                    var e = new Employees().GetEmployeeByUsername(username);
                    return (from u in ctx.Users
                            where u.UpnUsername == e.UpnUsername
                            from r in u.Roles
                            where r.Name == roleName
                            select r).Count() > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a list of the roles that a specified user is in for the configured applicationName.
        /// </summary>
        /// <returns>
        /// A string array containing the names of all the roles that the specified user is in for the configured applicationName.
        /// </returns>
        /// <param name="username">The user to return a list of roles for.</param>
        public override string[] GetRolesForUser(string username)
        {
            using (var ctx = new AppEntities())
            {
                var e = new Employees().GetEmployeeByUsername(username);
                return (from u in ctx.Users
                        where u.UpnUsername == e.UpnUsername
                        from r in u.Roles
                        select r.Name).ToArray();
            }
        }

        /// <summary>
        /// Adds a new role to the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to create.</param>
        public override void CreateRole(string roleName)
        {
            CreateRole(roleName, "");
        }

        /// <summary>
        /// Adds a new role to the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">Name of the role to create.</param>
        /// <param name="description">The description to assign to the role.</param>
        public void CreateRole(string roleName, string description)
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
                using (var context = new AppEntities())
                {
                    // Create new role
                    var newRole = new Role
                    {
                        RoleId = Guid.NewGuid(),
                        Name = roleName,
                        Description = description
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
        /// <returns>
        /// true if the role was successfully deleted; otherwise, false.
        /// </returns>
        /// <param name="roleName">The name of the role to delete.</param><param name="throwOnPopulatedRole">If true, throw an exception if <paramref name="roleName"/> has one or more members and do not delete <paramref name="roleName"/>.</param>
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

            using (var ctx = new AppEntities())
            {
                var role = ctx.Roles.Where(c => c.Name == roleName).FirstOrDefault();
                if (role == null) return false;

                try
                {
                    ctx.DeleteObject(role);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the specified role name already exists in the role data source for the configured applicationName.
        /// </summary>
        /// <returns>
        /// true if the role name already exists in the data source for the configured applicationName; otherwise, false.
        /// </returns>
        /// <param name="roleName">The name of the role to search for in the data source.</param>
        public override bool RoleExists(string roleName)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    return ctx.Roles.Where(c => c.Name == roleName).FirstOrDefault() != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Adds the specified user names to the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">A string array of user names to be added to the specified roles. </param><param name="roleNames">A string array of the role names to add the specified user names to.</param>
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            using (var ctx = new AppEntities())
            {

                var roles = ctx.Roles.Where(BuildContainsExpression<Role, string>(r => r.Name, roleNames));
                if (roles.Count() != roleNames.Length)
                {
                    throw new ProviderException("Role not found.");
                }

                var users = ctx.Users.Where(BuildContainsExpression<User, string>(u => u.UpnUsername, usernames));
                if (users.Count() != usernames.Length)
                {
                    foreach (var userid in usernames)
                    {
                        var e = new Employees().GetEmployeeByUsername(userid);
                        var user = new User { UserId = Guid.NewGuid(), Username = e.Username, UpnUsername = e.UpnUsername };
                        ctx.Users.AddObject(user);
                    }
                    ctx.SaveChanges();
                }

                try
                {
                    foreach (var user in users)
                    {
                        foreach (var role in roles)
                        {
                            // Check whether user is already in role
                            if (!IsUserInRole(user.UpnUsername, role.Name))
                            {
                                user.Roles.Add(role);
                            }
                        }
                    }

                    ctx.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                }
                catch
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Removes the specified user names from the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">A string array of user names to be removed from the specified roles. </param><param name="roleNames">A string array of role names to remove the specified user names from.</param>
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            using (var ctx = new AppEntities())
            {
                var roles = ctx.Roles.Where(BuildContainsExpression<Role, string>(r => r.Name, roleNames));
                if (roles.Count() != roleNames.Length)
                {
                    throw new ProviderException("Role not found.");
                }

                var users = ctx.Users.Include("Roles").Where(BuildContainsExpression<User, string>(u => u.UpnUsername, usernames));
                if (users.Count() != usernames.Length)
                {
                    throw new ProviderException("User not found.");
                }

                try
                {
                    foreach (var user in users)
                    {
                        foreach (var role in roles)
                        {
                            if (user.Roles.Contains(role))
                            {
                                user.Roles.Remove(role);
                            }
                        }
                    }
                    ctx.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
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
        /// <returns>
        /// A string array containing the names of all the users who are members of the specified role for the configured applicationName.
        /// </returns>
        /// <param name="roleName">The name of the role to get the list of users for.</param>
        public override string[] GetUsersInRole(string roleName)
        {
            using (var ctx = new AppEntities())
            {
                var role = ctx.Roles.Where(c => c.Name == roleName).FirstOrDefault();
                if (role == null) throw new ProviderException("Role not found.");

                if (!role.User.IsLoaded)
                {
                    role.User.Load();
                }

                return role.User.Select(u => u.UpnUsername).ToArray();
            }
        }

        /// <summary>
        /// Gets a list of all the roles for the configured applicationName.
        /// </summary>
        /// <returns>
        /// A string array containing the names of all the roles stored in the data source for the configured applicationName.
        /// </returns>
        public override string[] GetAllRoles()
        {
            using (var ctx = new AppEntities())
            {
                return ctx.Roles.Select(r => r.Name).ToArray();
            }
        }

        /// <summary>
        /// Gets an array of user names in a role where the user name contains the specified user name to match.
        /// </summary>
        /// <returns>
        /// A string array containing the names of all the users where the user name matches <paramref name="usernameToMatch"/> and the user is a member of the specified role.
        /// </returns>
        /// <param name="roleName">The role to search in.</param><param name="usernameToMatch">The user name to search for.</param>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            using (var ctx = new AppEntities())
            {
                var e = new Employees().GetEmployeeByUsername(usernameToMatch);
                var role = ctx.Roles.Where(c => c.Name == roleName).FirstOrDefault();
                if (role == null) throw new ProviderException("Role not found.");

                if (!role.User.IsLoaded)
                {
                    role.User.Load();
                }

                return role.User.Select(u => u.UpnUsername).Where(u => u.Contains(e.UpnUsername)).ToArray();
            }
        }

        /// <summary>
        /// Gets or sets the name of the application to store and retrieve role information for.
        /// </summary>
        /// <returns>
        /// The name of the application to store and retrieve role information for.
        /// </returns>
        public override string ApplicationName { get; set; }

        /// <summary>
        /// Gets all roles collection.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAllRolesCollection()
        {
            var d = new Dictionary<string, string>();
            using (var ctx = new AppEntities())
            {
                foreach (var r in ctx.Roles.OrderBy(c => c.Description))
                {
                    d.Add(r.Name, r.Description);
                }
                return d;
            }
        }

        /// <summary>
        /// Gets the users roles.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public string[] GetUsersRoles(string username)
        {
            using (var ctx = new AppEntities())
            {
                return ctx.Users.Where(c => c.UpnUsername == username).FirstOrDefault().Roles.Select(c => c.Name).ToArray();
            }
        }

        /// <summary>
        /// Gets the employees with roles.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDTO> GetEmployeesWithRoles()
        {
            using (var ctx = new AppEntities())
            {
                var r = new List<EmployeeDTO>();
                var e = new Employees();
                foreach (var u in ctx.Users.Where(c => c.Roles.Count > 0))
                {
                    var t = e.GetEmployeeByUsername(u.UpnUsername);
                    if (t != null)
                        r.Add(t);
                }
                return r.OrderBy(c => c.SortName).ToList();
            }
        }

        /// <summary>
        /// Updates the user roles.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        public bool UpdateUserRoles(string username, Dictionary<string, bool> roles)
        {
            var e = new Employees().GetEmployeeByUsername(username);
            if (e == null) return false;

            using (var ctx = new AppEntities())
            {
                var addRoles = roles.Where(r => r.Value).Select(r => r.Key).ToArray();
                var remRoles = roles.Where(r => !r.Value).Select(r => r.Key).ToArray();
                if (ctx.Users.Where(c => c.UpnUsername == e.UpnUsername).Count() > 0)
                {
                    // User already exists, remove roles that have changed
                    RemoveUsersFromRoles(new[] { e.UpnUsername }, remRoles);

                    // Now add them to all new roles
                    AddUsersToRoles(new[] { e.UpnUsername }, addRoles);
                    return true;
                }
                // User does not exist, add roles
                AddUsersToRoles(new[] { e.UpnUsername }, addRoles);
                return true;
            }
        }

        /// <summary>
        /// Builds a contains expression.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="valueSelector">The value selector.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        private static Expression<Func<TElement, bool>> BuildContainsExpression<TElement, TValue>(Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
        {
            if (null == valueSelector)
            {
                throw new ArgumentNullException("valueSelector");
            }

            if (null == values)
            {
                throw new ArgumentNullException("values");
            }

            var p = valueSelector.Parameters.Single();

            if (!values.Any())
            {
                return e => false;
            }

            var equals = values.Select(value => (Expression)Expression.Equal(valueSelector.Body, Expression.Constant(value, typeof(TValue))));
            var body = equals.Aggregate(Expression.Or);
            return Expression.Lambda<Func<TElement, bool>>(body, p);
        }
    }
}

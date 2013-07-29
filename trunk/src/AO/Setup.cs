namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;

    using THS.UMS.AO.Providers;

    public class Setup
    {
        /// <summary>
        /// Verifies the connection string.
        /// </summary>
        /// <param name="connString">The connection string to test.</param>
        /// <returns></returns>
        public bool VerifyConnectionString(string connString)
        {
            // Use plain old ADO.NET commands to verify the template table is in place
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    const string sql = "SELECT Count(TemplateId) as RetVal FROM EmailTemplates";
                    var cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    var ret = Convert.ToInt32(cmd.ExecuteScalar());

                    return ret > 0;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets the directory settings.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAdSettings()
        {
            var adPath = AppSettings.GetValue("AdPath");
            var adUser = AppSettings.GetValue("AdUser");
            var adPass = AppSettings.GetValue("AdUserPass");

            if (adPath.Length > 7) adPath = adPath.Substring(7);

            var dic = new Dictionary<string, string>
                          {
                              {"AdPath", adPath},
                              {"AdUser", adUser},
                              {"AdUserPass", adPass}
                          };
            return dic;
        }

        /// <summary>
        /// Verifies the directory access.
        /// </summary>
        /// <param name="d">The directory.</param>
        /// <param name="u">The username.</param>
        /// <param name="p">The password.</param>
        /// <param name="server">The server.</param>
        /// <returns></returns>
        public bool VerifyDirectoryAccess(string d, string u, string p, out string server)
        {
            server = "";
            try
            {
                using (var ctx = new PrincipalContext(ContextType.Domain, d, null, ContextOptions.Negotiate, u, p))
                {
                    var user = UserPrincipal.FindByIdentity(ctx, UserPrincipal.Current.UserPrincipalName);
                    if (user == null) return false;
                    user.UnlockAccount();
                    server = ctx.ConnectedServer;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the user exist.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public bool DoesUserExist(out string username)
        {
            // Start with nothing
            username = "";

            // Get users in admin portal role
            var apUsers = new Roles().GetUsersInRole("AdminPortal");

            // Make sure we have some
            if (apUsers.Length == 0) return false;

            // Cycle through and make sure one of them has configuration rights
            var users = apUsers.Where(u => new Roles().IsUserInRole(u, "Configuration")).ToList();

            if (users.Count == 0) return false;

            username = users.FirstOrDefault().ToLower();
            return true;
        }

        /// <summary>
        /// Adds the admin user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public bool AddAdminUser(string username)
        {
            var roles = new[] { "Configuration", "AdminPortal" };

            try
            {
                new Roles().AddUsersToRoles(new[] { username }, roles);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the app title.
        /// </summary>
        /// <returns></returns>
        public string GetAppTitle()
        {
            return AppSettings.GetValue("AppTitle");
        }
    }
}

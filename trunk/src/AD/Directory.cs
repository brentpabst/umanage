namespace THS.UMS.AD
{
    using System.DirectoryServices.AccountManagement;

    public class Directory
    {
        /// <summary>
        /// Verifies the connection to the directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool VerifyConnection(string directory, string username, string password)
        {
            try
            {
                using (var ctx = new PrincipalContext(ContextType.Domain, directory, null, ContextOptions.Negotiate, username, password))
                {
                    var u = UserPrincipal.FindByIdentity(ctx, username);
                    if (u != null)
                    {
                        u.UnlockAccount();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

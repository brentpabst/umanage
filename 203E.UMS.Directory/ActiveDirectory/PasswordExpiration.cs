using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace _203E.UMS.Directory.ActiveDirectory
{
    internal class PasswordExpiration
    {
        #region Constants
        const int UfDontExpirePasswd = 0x10000;
        #endregion

        #region Properties
        private readonly DirectoryPolicy _policy;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordExpiration"/> class.
        /// </summary>
        internal PasswordExpiration()
        {
            //Get Password Expiration
            var domain = Domain.GetCurrentDomain();
            var root = domain.GetDirectoryEntry();

            using (domain)
            using (root)
            {
                _policy = new DirectoryPolicy(root);
            }
        }
        #endregion

        #region Internal
        /// <summary>
        /// Gets the expiration.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">User does not have a password</exception>
        internal DateTime GetExpiration(DirectoryEntry user)
        {
            var flags = (int)user.Properties["userAccountControl"][0];

            if (Convert.ToBoolean(flags & UfDontExpirePasswd))
            {
                return DateTime.MaxValue;
            }

            var ticks = user.GetLastPasswordTicks();

            if (ticks == 0)
                return DateTime.MinValue;

            if (ticks == -1)
            {
                throw new InvalidOperationException("User does not have a password");
            }

            var pwdLastSet = DateTime.FromFileTime(ticks);

            return _policy.MaxPasswordAge == TimeSpan.MaxValue ? DateTime.MaxValue : pwdLastSet.Add(_policy.MaxPasswordAge);
        }
        #endregion
    }
}

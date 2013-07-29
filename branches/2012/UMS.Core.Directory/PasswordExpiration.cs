using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using UMS.Core.Directory.Extensions;

namespace UMS.Core.Directory
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

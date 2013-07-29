namespace THS.UMS.AD
{
    using System;
    using System.DirectoryServices;
    using System.DirectoryServices.ActiveDirectory;

    public class PasswordExpiration
    {
        #region Constants

        const int UfDontExpirePasswd = 0x10000;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current domain policy
        /// </summary>
        public readonly DomainPolicy Policy;

        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor
        /// </summary>
        public PasswordExpiration()
        {
            //Get Password Expiration
            Domain domain = Domain.GetCurrentDomain();
            DirectoryEntry root = domain.GetDirectoryEntry();

            using (domain)
            using (root)
            {
                Policy = new DomainPolicy(root);
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Returns the Password Expiration Date for a User
        /// </summary>
        /// <remarks>
        /// The DateTime returned may not be the actual password expiration date, instead
        /// it may consist of DateTime.MaxValue and DateTime.MinValue with MaxValue corresponding
        /// to the user's password never expiring while MinValue represents that the password is already
        /// expired.
        /// </remarks>
        /// <param name="user">DirectoryEntry representing the current UserPrincipal</param>
        /// <returns></returns>
        public DateTime GetExpiration(DirectoryEntry user)
        {
            var flags = (int)user.Properties["userAccountControl"][0];

            //See if password is set to expire
            if (Convert.ToBoolean(flags & UfDontExpirePasswd))
            {
                //Password is set to never expire
                return DateTime.MaxValue;
            }

            long ticks = GetInt64(user, "pwdLastSet");

            //User must change password at next login
            if (ticks == 0)
                return DateTime.MinValue;

            //Password never set
            if (ticks == -1)
            {
                throw new InvalidOperationException("User does not have a password");
            }

            //Get the last set datetime
            DateTime pwdLastSet = DateTime.FromFileTime(ticks);

            //Now figure out when it will expire
            if (Policy.MaxPasswordAge == TimeSpan.MaxValue)
            {
                return DateTime.MaxValue;
            }
            return pwdLastSet.Add(Policy.MaxPasswordAge);
        }

        #endregion

        #region Private

        /// <summary>
        /// Helper class for building <see cref="System.Int64"/> from <see cref="DirectoryEntry"/>.
        /// </summary>
        /// <param name="entry">DirectoryEntry representing the current UserPrincipal</param>
        /// <param name="attr">The Attribute value to return</param>
        /// <returns></returns>
        private static Int64 GetInt64(DirectoryEntry entry, string attr)
        {
            var ds = new DirectorySearcher(entry, String.Format("({0}=*)", attr), new[] { attr }, SearchScope.Base);

            var sr = ds.FindOne();

            if (sr != null)
            {
                if (sr.Properties.Contains(attr))
                    return (Int64)sr.Properties[attr][0];
            }
            return -1;
        }

        #endregion
    }
}

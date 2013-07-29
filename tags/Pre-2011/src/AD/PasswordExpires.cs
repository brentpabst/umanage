using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace PPI.UMS.AD
{
    /// <summary>
    /// Class that assists with determining the user password expiration date
    /// </summary>
    public class PasswordExpires
    {
        #region Constants

        const int UF_DONT_EXPIRE_PASSWD = 0x10000;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current domain policy
        /// </summary>
        DomainPolicy policy;

        #endregion

        #region Constructor
        
        /// <summary>
        /// The default constructor
        /// </summary>
        public PasswordExpires()
        {
            //Get Password Expiration
            Domain domain = Domain.GetCurrentDomain();
            DirectoryEntry root = domain.GetDirectoryEntry();

            using (domain)
            using (root)
            {
                this.policy = new DomainPolicy(root);
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
            int flags = (int)user.Properties["userAccountControl"][0];

            //See if password is set to expire
            if (Convert.ToBoolean(flags & UF_DONT_EXPIRE_PASSWD))
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
            if (this.policy.MaxPasswordAge == TimeSpan.MaxValue)
            {
                return DateTime.MaxValue;
            }
            return pwdLastSet.Add(this.policy.MaxPasswordAge);
        }

        #endregion

        #region Private

        /// <summary>
        /// Helper class for building <see cref="System.Int64"/> from <see cref="DirectoryEntry"/>.
        /// </summary>
        /// <param name="entry">DirectoryEntry representing the current UserPrincipal</param>
        /// <param name="attr">The Attribute value to return</param>
        /// <returns></returns>
        private Int64 GetInt64(DirectoryEntry entry, string attr)
        {
            DirectorySearcher ds = new DirectorySearcher(entry, String.Format("({0}=*)", attr), new string[] { attr }, SearchScope.Base);

            SearchResult sr = ds.FindOne();

            if (sr != null)
            {
                if (sr.Properties.Contains(attr))
                {
                    return (Int64)sr.Properties[attr][0];
                }
            }
            return -1;
        }

        #endregion
    }
}

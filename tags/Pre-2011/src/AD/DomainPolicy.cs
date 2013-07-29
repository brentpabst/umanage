using System;
using System.DirectoryServices;

namespace PPI.UMS.AD
{
    /// <summary>
    /// A set of properties and methods that represent Active Directory Policies
    /// </summary>
    public class DomainPolicy
    {
        #region Properties

        /// <summary>
        /// A list of attributes for a domain
        /// </summary>
        ResultPropertyCollection attribs;

        /// <summary>
        /// A set of password storage options
        /// </summary>
        [Flags]
        public enum PasswordPolicy
        {
            DOMAIN_PASSWORD_COMPLEX = 1,
            DOMAIN_PASSWORD_NO_ANON_CHANGE = 2,
            DOMAIN_PASSWORD_NO_CLEAR_CHANGE = 4,
            DOMAIN_LOCKOUT_ADMINS = 8,
            DOMAIN_PASSWORD_STORE_CLEARTEXT = 16,
            DOMAIN_REFUSE_PASSWORD_CHANGE = 32
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Class that gets the Group Policy Security Settings for the domain
        /// </summary>
        public DomainPolicy(DirectoryEntry domainRoot)
        {
            string[] policyAttributes = new string[]
            {"maxPwdAge", "minPwdAge", "minPwdLength", "lockoutDuration", "lockOutObservationWindow", 
             "lockoutThreshold", "pwdProperties", "pwdHistoryLength", "objectClass", "distinguishedName"};

            //Search for the policy
            DirectorySearcher ds = new DirectorySearcher(domainRoot, "(objectClass=domainDNS)", policyAttributes, SearchScope.Base);

            //Locate the one and only
            SearchResult result = ds.FindOne();

            //Be nice to the RAM
            ds.Dispose();

            //Make sure we have a record
            if (result == null)
            {
                throw new ArgumentException("Selected DirectoryEntry is not a valid domainDNS or root-level entry");
            }

            //Populate the results
            this.attribs = result.Properties;
        }

        #endregion

        #region Private

        /// <summary>
        /// Get a properly formated long integer
        /// </summary>
        /// <param name="longInt">Value representing time or date</param>
        /// <returns><see cref="Int64"/>A proper long integer</returns>
        private long GetAbsValue(object longInt)
        {
            long val = (long)longInt;
            if (val == long.MinValue)
                return TimeSpan.MaxValue.Ticks;
            return Math.Abs((long)longInt);
        }

        #endregion

        #region Public

        /// <summary>
        /// Returns the Maximum Password Age from the GPO Policy
        /// </summary>
        public TimeSpan MaxPasswordAge
        {
            get
            {
                string val = "maxPwdAge";
                if (this.attribs.Contains(val))
                {
                    long ticks = GetAbsValue(
                      this.attribs[val][0]
                      );

                    if (ticks > 0)
                        return TimeSpan.FromTicks(ticks);
                }

                return TimeSpan.MaxValue;
            }
        }

        /// <summary>
        /// Returns a <see cref="PasswordPolicy"/> collection of the standard GPO security settings
        /// </summary>
        public PasswordPolicy PasswordProperties
        {
            get
            {
                string val = "pwdProperties";
                //this should fail if not found
                return (PasswordPolicy)this.attribs[val][0];
            }
        }

        #endregion
    }

    
}

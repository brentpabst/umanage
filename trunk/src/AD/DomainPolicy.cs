namespace THS.UMS.AD
{
    using System;
    using System.DirectoryServices;

    public class DomainPolicy
    {
        #region Properties

        /// <summary>
        /// A list of attributes for a domain
        /// </summary>
        readonly ResultPropertyCollection _attribs;

        /// <summary>
        /// A set of password storage options
        /// </summary>
        [Flags]
        public enum PasswordPolicy
        {
            DomainPasswordComplex = 1,
            DomainPasswordNoAnonChange = 2,
            DomainPasswordNoClearChange = 4,
            DomainLockoutAdmins = 8,
            DomainPasswordStoreCleartext = 16,
            DomainRefusePasswordChange = 32
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Class that gets the Group Policy Security Settings for the domain
        /// </summary>
        public DomainPolicy(DirectoryEntry domainRoot)
        {
            var policyAttributes = new[]
            {"maxPwdAge", "minPwdAge", "minPwdLength", "lockoutDuration", "lockOutObservationWindow", 
             "lockoutThreshold", "pwdProperties", "pwdHistoryLength", "objectClass", "distinguishedName"};

            //Search for the policy
            var ds = new DirectorySearcher(domainRoot, "(objectClass=domainDNS)", policyAttributes, SearchScope.Base);

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
            _attribs = result.Properties;
        }

        #endregion

        #region Private

        /// <summary>
        /// Get a properly formated long integer
        /// </summary>
        /// <param name="longInt">Value representing time or date</param>
        /// <returns><see cref="Int64"/>A proper long integer</returns>
        private static long GetAbsValue(object longInt)
        {
            var val = (long)longInt;
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
                const string val = "maxPwdAge";
                if (_attribs.Contains(val))
                {
                    long ticks = GetAbsValue(
                      _attribs[val][0]
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
                const string val = "pwdProperties";
                //this should fail if not found
                return (PasswordPolicy)_attribs[val][0];
            }
        }

        #endregion
    }
}

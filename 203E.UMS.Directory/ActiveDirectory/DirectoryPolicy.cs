using _203E.UMS.Extensions;
using System;
using System.DirectoryServices;

namespace _203E.UMS.Directory.ActiveDirectory
{
    internal class DirectoryPolicy
    {
        readonly ResultPropertyCollection _attribs;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryPolicy"/> class.
        /// </summary>
        /// <param name="domainRoot">The domain root.</param>
        /// <exception cref="System.ArgumentException">Selected DirectoryEntry is not a valid domainDNS or root-level entry</exception>
        internal DirectoryPolicy(DirectoryEntry domainRoot)
        {
            var policyAttributes = new[]
            {
                "maxPwdAge", 
                "minPwdAge", 
                "minPwdLength", 
                "lockoutDuration", 
                "lockOutObservationWindow", 
                "lockoutThreshold", 
                "pwdProperties", 
                "pwdHistoryLength", 
                "objectClass", 
                "distinguishedName"
            };

            //Search for the policy
            var ds = new DirectorySearcher(domainRoot, "(objectClass=domainDNS)", policyAttributes, SearchScope.Base);

            //Locate the one and only
            // TODO: Research this, in Win Server 2008+ you can have more than one password policy
            var result = ds.FindOne();

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

        #region Public
        /// <summary>
        /// Gets the maximum password age.
        /// </summary>
        /// <value>
        /// The maximum password age.
        /// </value>
        internal TimeSpan MaxPasswordAge
        {
            get
            {
                const string val = "maxPwdAge";
                if (_attribs.Contains(val))
                {
                    var ticks = _attribs[val][0].ToAbsolute();
                    if (ticks > 0)
                        return TimeSpan.FromTicks(ticks);
                }
                return TimeSpan.MaxValue;
            }
        }

        /// <summary>
        /// Gets the password properties.
        /// </summary>
        /// <value>
        /// The password properties.
        /// </value>
        internal PasswordPolicy PasswordProperties
        {
            get
            {
                const string val = "pwdProperties";
                return (PasswordPolicy)_attribs[val][0];
            }
        }
        #endregion
    }
}

using _203.UMS.Directory.Enums;
using _203.UMS.Extensions;
using System;
using System.DirectoryServices;

namespace _203.UMS.Directory
{
    internal class DirectoryPolicy
    {
        readonly ResultPropertyCollection _attribs;

        #region Constructor
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
            // TODO: Research this, in 2008 or R2 you can have more than one password policy, could be a problem.
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

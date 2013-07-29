using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace PPI.UMS.AD
{
    public static class Common
    {
        public static ProviderSettings GetWebMembershipDetails()
        {
            MembershipSection ms = (MembershipSection)WebConfigurationManager.GetSection("system.web/membership");
            return ms.Providers["AspNetActiveDirectoryMembershipProvider"];
        }

        public static string GetDomainName(ConnectionStringSettings conString)
        {
            string retVal = "";

            if (conString.ConnectionString.ToLower().StartsWith("ldap://"))
            {
                retVal = conString.ConnectionString.Substring(7);
            }

            return retVal;
        }

        public static string GetDisplayName(string firstName, string middleName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(middleName))
                return firstName + " " + lastName;
            else
                if (middleName.Length > 2)
                    return firstName + " " + middleName.Remove(1) + ". " + lastName;
                else
                    return firstName + " " + middleName + ". " + lastName;
        }
    }
}

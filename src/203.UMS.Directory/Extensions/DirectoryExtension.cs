using System;
using System.DirectoryServices;

namespace _203.UMS.Directory.Extensions
{
    internal static class DirectoryExtension
    {
        internal static Int64 GetLastPasswordTicks(this DirectoryEntry d)
        {
            const string attr = "pwdLastSet";

            var ds = new DirectorySearcher(d, String.Format("({0}=*)", attr), new[] { attr }, SearchScope.Base);
            var r = ds.FindOne();
            if (r != null)
            {
                if (r.Properties.Contains(attr))
                    return (Int64)r.Properties[attr][0];
            }
            return -1;
        }

        internal static string GetProperty(this DirectoryEntry d, string p)
        {
            var v = d.Properties[p].Value;
            return v != null ? v.ToString() : null;
        }
    }
}

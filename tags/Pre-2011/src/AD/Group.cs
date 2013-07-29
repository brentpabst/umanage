using System;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Collections.Generic;

namespace PPI.UMS.AD
{
    public class Group
    {
        public List<User> GetGroupMembers(string Group)
        {
            try
            {
                ProviderSettings ps = Common.GetWebMembershipDetails();

                if (ps.Parameters.HasKeys())
                {
                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, Common.GetDomainName(ConfigurationManager.ConnectionStrings["ADService"]), null, ContextOptions.Negotiate, ps.Parameters["connectionUsername"], ps.Parameters["connectionPassword"]))
                    {
                        GroupPrincipal group = GroupPrincipal.FindByIdentity(context, Group);
                        List<User> users = new List<User>();

                        foreach (Principal principal in group.Members)
                        {
                            users.Add(new User(principal.DistinguishedName));
                        }
                        return users;
                    }
                }
                else
                {
                    throw new ApplicationException("The configuration information for the domain could not be read!");
                }
            }
            catch
            {
                return null;
            }
        }
    }
}

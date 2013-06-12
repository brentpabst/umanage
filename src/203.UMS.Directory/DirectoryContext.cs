using System.DirectoryServices.AccountManagement;
using _203.UMS.Models.Config;

namespace _203.UMS.Directory
{
    public static class DirectoryContext
    {
        public static PrincipalContext Get(DirectorySetting settings)
        {
            return new PrincipalContext(ContextType.Domain,
                     settings.Directory,
                     settings.Container,
                     ContextOptions.Negotiate,
                     settings.Username,
                     settings.Password);
        }
    }
}

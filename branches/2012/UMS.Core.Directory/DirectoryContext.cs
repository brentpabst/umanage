using System.DirectoryServices.AccountManagement;
using UMS.Core.Data.Models.Config;

namespace UMS.Core.Directory
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

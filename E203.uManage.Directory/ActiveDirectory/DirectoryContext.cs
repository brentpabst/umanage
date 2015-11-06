using System.Configuration;
using System.DirectoryServices.AccountManagement;

namespace S203.uManage.Directory.ActiveDirectory
{
    public class DirectoryContext : IDirectoryContext
    {
        private readonly DirectorySettings _settings;

        public DirectoryContext()
        {
            // TODO: Replace this with something far more durable
            _settings = new DirectorySettings
            {
                Directory = ConfigurationManager.AppSettings["Directory"],
                Container = ConfigurationManager.AppSettings["Container"],
                Username = ConfigurationManager.AppSettings["Username"],
                Password = ConfigurationManager.AppSettings["Password"]
            };
        }

        public PrincipalContext LoadAndConnect()
        {
            return new PrincipalContext(ContextType.Domain,
                _settings.Directory,
                _settings.Container,
                ContextOptions.Negotiate,
                _settings.Username,
                _settings.Password);
        }
    }
}

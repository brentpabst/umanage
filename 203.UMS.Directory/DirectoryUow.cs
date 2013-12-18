using _203.UMS.Directory.Repositories;
using _203.UMS.Directory.Repositories.Interfaces;
using _203.UMS.Models.Config;
using System;
using System.DirectoryServices.AccountManagement;

namespace _203.UMS.Directory
{
    public class DirectoryUow : IDisposable
    {
        #region Properties
        private PrincipalContext Dir { get; set; }
        public string ConnectedServer { get { return Dir.ConnectedServer; } }
        #endregion

        #region Ctor
        public DirectoryUow(DirectorySettings settings)
        {
            Dir = new PrincipalContext(
                ContextType.Domain,
                settings.Directory,
                settings.Container,
                ContextOptions.Negotiate,
                settings.Username,
                settings.Password);
        }
        #endregion

        public IRepository<Models.Directory.Principal> Directory { get { return new DirectoryRepository(Dir); } }
        public UserRepository Users { get { return new UserRepository(Dir); } }

        #region Disposal
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Dir != null)
            {
                Dir.Dispose();
            }
        }
        #endregion
    }
}

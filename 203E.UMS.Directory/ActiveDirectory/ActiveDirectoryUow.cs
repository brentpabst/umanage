using _203E.UMS.Models;
using System;
using System.DirectoryServices.AccountManagement;

namespace _203E.UMS.Directory.ActiveDirectory
{
    public class ActiveDirectoryUow : IDirectoryUow
    {
        private PrincipalContext Ctx { get; set; }

        #region Ctor
        public ActiveDirectoryUow(DirectorySettings settings)
        {
            Ctx = new PrincipalContext(
                ContextType.Domain,
                settings.Directory,
                settings.Container,
                ContextOptions.Negotiate,
                settings.Username,
                settings.Password);
        }
        #endregion

        public string ConnectedServer { get; set; }
        public IDirectoryRepository Directory { get { return new DirectoryRepository(Ctx); } }
        public IUserRepository Users { get { return new UserRepository(Ctx); } }

        #region Disposal
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Ctx != null)
            {
                Ctx.Dispose();
            }
        }
        #endregion
    }
}

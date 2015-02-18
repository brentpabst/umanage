using System;
using System.DirectoryServices.AccountManagement;
using uManange.Models;

namespace uManage.Directories.ActiveDirectory
{
    public class ActiveDirectoryService:IDirectoryService
    {
        private PrincipalContext Ctx { get; set; }

        #region Ctor
        public ActiveDirectoryService(DirectorySettings settings)
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

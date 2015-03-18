using System;
using System.DirectoryServices.AccountManagement;
using uManage.Models;

namespace uManage.Directories.ActiveDirectory
{
    /// <summary>
    /// Active Directory Service
    /// </summary>
    public class ActiveDirectoryService:IDirectoryService
    {
        private PrincipalContext Ctx { get; set; }

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveDirectoryService"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
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

        /// <summary>
        /// Gets or sets the connected server.
        /// </summary>
        /// <value>
        /// The connected server.
        /// </value>
        public string ConnectedServer { get; set; }
        /// <summary>
        /// Gets the directory repository.
        /// </summary>
        /// <value>
        /// The directory repository.
        /// </value>
        public IDirectoryRepository Directory { get { return new DirectoryRepository(Ctx); } }
        /// <summary>
        /// Gets the users repository.
        /// </summary>
        /// <value>
        /// The users repository.
        /// </value>
        public IUserRepository Users { get { return new UserRepository(Ctx); } }

        #region Disposal
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
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

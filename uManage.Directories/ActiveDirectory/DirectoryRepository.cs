using System;
using System.DirectoryServices.AccountManagement;
using uManage.Models;

namespace uManage.Directories.ActiveDirectory
{
    /// <summary>
    /// Directory Repository
    /// </summary>
    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly PrincipalContext _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryRepository"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public DirectoryRepository(PrincipalContext ctx)
        {
            if (_ctx == null)
                _ctx = ctx;
        }

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <param name="directoryId">The directory identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Directory GetDirectory(Guid directoryId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool UpdateDirectory(Directory directory)
        {
            throw new NotImplementedException();
        }
    }
}

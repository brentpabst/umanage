using System;
using uManage.Models;

namespace uManage.Directories
{
    /// <summary>
    /// Directory Repository
    /// </summary>
    public interface IDirectoryRepository
    {
        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <param name="directoryId">The directory identifier.</param>
        /// <returns></returns>
        Directory GetDirectory(Guid directoryId);
        /// <summary>
        /// Updates the directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <returns></returns>
        bool UpdateDirectory(Directory directory);
    }
}

using System;

namespace _203E.UMS.Directory
{
    public interface IDirectoryRepository
    {
        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <param name="directoryId">The directory identifier.</param>
        /// <returns></returns>
        Models.Directory GetDirectory(Guid directoryId);
        /// <summary>
        /// Updates the directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <returns></returns>
        bool UpdateDirectory(Models.Directory directory);
    }
}

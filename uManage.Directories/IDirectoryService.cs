using System;

namespace uManage.Directories
{
    /// <summary>
    /// Directory Service
    /// </summary>
    public interface IDirectoryService : IDisposable
    {
        /// <summary>
        /// Gets or sets the connected server.
        /// </summary>
        /// <value>
        /// The connected server.
        /// </value>
        string ConnectedServer { get; set; }
        /// <summary>
        /// Gets the directory repository.
        /// </summary>
        /// <value>
        /// The directory repository.
        /// </value>
        IDirectoryRepository Directory { get; }
        /// <summary>
        /// Gets the users repository.
        /// </summary>
        /// <value>
        /// The users repository.
        /// </value>
        IUserRepository Users { get; }
    }
}

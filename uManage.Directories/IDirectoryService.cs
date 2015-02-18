using System;

namespace uManage.Directories
{
    public interface IDirectoryService : IDisposable
    {
        string ConnectedServer { get; set; }
        IDirectoryRepository Directory { get; }
        IUserRepository Users { get; }
    }
}

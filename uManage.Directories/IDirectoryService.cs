using System;

namespace uManage.Directories
{
    public interface IDirectoryUow : IDisposable
    {
        string ConnectedServer { get; set; }
        IDirectoryRepository Directory { get; }
        IUserRepository Users { get; }
    }
}

using System;

namespace _203E.UMS.Directory
{
    public interface IDirectoryUow : IDisposable
    {
        string ConnectedServer { get; set; }
        IDirectoryRepository Directory { get; }
        IUserRepository Users { get; }
    }
}

using System.DirectoryServices.AccountManagement;

namespace E203.uManage.Directory
{
    public interface IDirectoryContext
    {
        PrincipalContext LoadAndConnect();
    }
}

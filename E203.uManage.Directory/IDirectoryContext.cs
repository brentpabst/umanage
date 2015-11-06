using System.DirectoryServices.AccountManagement;

namespace S203.uManage.Directory
{
    public interface IDirectoryContext
    {
        PrincipalContext LoadAndConnect();
    }
}

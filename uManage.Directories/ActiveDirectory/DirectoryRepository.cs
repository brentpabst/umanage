using System;
using System.DirectoryServices.AccountManagement;
using uManange.Models;

namespace uManage.Directories.ActiveDirectory
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private PrincipalContext _ctx;
        public DirectoryRepository(PrincipalContext ctx)
        {
            if (_ctx == null)
                _ctx = ctx;
        }

        public Directory GetDirectory(Guid directoryId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDirectory(Directory directory)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.DirectoryServices.AccountManagement;

namespace _203E.UMS.Directory.ActiveDirectory
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private PrincipalContext _ctx;
        public DirectoryRepository(PrincipalContext ctx)
        {
            if (_ctx == null)
                _ctx = ctx;
        }

        public Models.Directory GetDirectory(Guid directoryId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDirectory(Models.Directory directory)
        {
            throw new NotImplementedException();
        }
    }
}

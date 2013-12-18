using _203.UMS.Directory.Repositories.Interfaces;
using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using Principal = _203.UMS.Models.Directory.Principal;

namespace _203.UMS.Directory.Repositories
{
    public class DirectoryRepository : IRepository<Principal>
    {
        private PrincipalContext Ctx { get; set; }
        public DirectoryRepository(PrincipalContext dir)
        {
            if (dir != null)
                Ctx = dir;
        }

        public IQueryable<Principal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Principal Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Principal entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Principal entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

using _203.UMS.Directory.Extensions;
using _203.UMS.Directory.Repositories.Interfaces;
using _203.UMS.Models.Directory;
using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace _203.UMS.Directory.Repositories
{
    public class UserRepository : IRepository<User>
    {
        #region Ctor
        private PrincipalContext Ctx { get; set; }
        public UserRepository(PrincipalContext dir)
        {
            if (dir != null)
                Ctx = dir;
        }
        #endregion

        public IQueryable<User> GetAll()
        {
            var u = new UserPrincipal(Ctx) { DisplayName = "*", Enabled = true };
            using (var ps = new PrincipalSearcher(u))
            {
                ps.QueryFilter = u;
                return ps.FindAll().OfType<UserPrincipal>().AsUserQueryable();
            }
        }

        public User Get(string id)
        {
            return UserPrincipal.FindByIdentity(Ctx, id).AsUser();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}

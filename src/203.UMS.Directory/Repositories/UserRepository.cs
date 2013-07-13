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
            var u = new UserPrincipal(Ctx) { DisplayName = "*" };
            using (var ps = new PrincipalSearcher(u))
            {
                ps.QueryFilter = u;
                return ps.FindAll().OfType<UserPrincipal>().AsUserQueryable();
            }
        }

        public User Get(Guid id)
        {
            return UserPrincipal.FindByIdentity(Ctx, id.ToString()).AsUser();
        }

        public User Get(string upn)
        {
            return UserPrincipal.FindByIdentity(Ctx, upn).AsUser();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, entity.UserId.ToString());
            p.MergeUser(entity);
            if (p != null) p.Save();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        
        public bool Enable(Guid id)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, id.ToString());
            if (p == null) return false;
            p.Enabled = true;
            p.Save();
            return true;
        }
        
        public bool Disable(Guid id)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, id.ToString());
            if (p == null) return false;
            p.Enabled = false;
            p.Save();
            return true;
        }
        
        public bool Unlock(Guid id)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, id.ToString());
            if (p == null) return false;
            p.UnlockAccount();
            p.Save();
            return true;
        }

        public bool ExpirePassword(Guid id)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, id.ToString());
            if (p == null) return false;
            p.ExpirePasswordNow();
            p.Save();
            return true;
        }
        
        public bool SetPassword(Guid id, string pass)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, id.ToString());
            if (p == null) return false;
            // Requires Domain Admin rights
            p.SetPassword(pass);
            p.Save();
            return true;
        }
    }
}

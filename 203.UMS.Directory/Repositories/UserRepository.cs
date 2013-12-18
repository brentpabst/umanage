using System.DirectoryServices;
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

        public bool Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, entity.UserId.ToString());
            if (p == null) return false;
            p.MergeUser(entity);
            p.Save();
            return true;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException("This system will never delete user accounts, use disable instead.");
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
            p.SetPassword(pass);
            p.Save();
            return true;
        }

        public bool ClearPhoto(Guid id)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, id.ToString());
            if (p == null) return false;

            var e = p.GetUnderlyingObject() as DirectoryEntry;
            if (e == null) return false;

            e.SetProperty("jpegPhoto", "");
            e.SetProperty("thumbnailPhoto", "");
            p.Save();

            return true;
        }

        public byte[] GetPhoto(Guid id)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, id.ToString());
            if (p == null) return null;

            var e = p.GetUnderlyingObject() as DirectoryEntry;
            if (e == null) return null;

            return (byte[])e.Properties["jpegPhoto"].Value;
        }

        public bool UpdatePhoto(Guid id, byte[] photo)
        {
            var p = UserPrincipal.FindByIdentity(Ctx, id.ToString());
            if (p == null) return false;

            var e = p.GetUnderlyingObject() as DirectoryEntry;
            if (e == null) return false;

            // Not using the extension method here as it doesn't currently support byte arrays
            e.Properties["jpegPhoto"].Value = photo;
            e.Properties["thumbnailPhoto"].Value = photo;
            p.Save();
            
            return true;
        }
    }
}

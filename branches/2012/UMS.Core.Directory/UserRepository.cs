using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using UMS.Core.Data.Models.Config;
using UMS.Core.Data.Models.Directory;
using UMS.Core.Directory.Extensions;

namespace UMS.Core.Directory
{
    public class UserRepository : IRepository<User>
    {
        #region Private Variables
        private readonly DirectorySetting _settings;
        #endregion

        #region Constructor
        public UserRepository(DirectorySetting settings)
        {
            if (_settings == null) _settings = settings;
        }
        #endregion

        public IQueryable<User> All
        {
            get
            {
                using (var ctx = DirectoryContext.Get(_settings))
                {
                    var u = new UserPrincipal(ctx) { DisplayName = "*", Enabled = true };
                    using (var ps = new PrincipalSearcher(u))
                    {
                        ps.QueryFilter = u;
                        return ps.FindAll().OfType<UserPrincipal>().AsUserQueryable();
                    }
                }
            }
        }

        public User Find(string name)
        {
            using (var ctx = DirectoryContext.Get(_settings))
            {
                return UserPrincipal.FindByIdentity(ctx, name).AsUser();
            }
        }

        public User InsertOrUpdate(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }
    }
}

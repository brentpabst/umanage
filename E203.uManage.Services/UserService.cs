using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using E203.uManage.Directory;
using E203.uManage.Services.Extensions;
using E203.uManage.Services.Models;
using System.Linq;

namespace E203.uManage.Services
{
    public class UserService : IUserService
    {
        private readonly IDirectoryContext _directoryContext;

        public UserService(IDirectoryContext directoryContext)
        {
            if (_directoryContext == null)
                _directoryContext = directoryContext;
        }

        public Task<List<User>> GetAllUsers()
        {
            using (var ctx = _directoryContext.LoadAndConnect())
            {
                var filter = new UserPrincipal(ctx) { DisplayName = "*", Enabled = true };
                using (var search = new PrincipalSearcher(filter))
                {
                    var users = search.FindAll().OfType<UserPrincipal>().AsUserList();
                    return Task.FromResult(users);
                }
            }
        }

        public Task<User> GetUser(Guid userId)
        {
            using (var ctx = _directoryContext.LoadAndConnect())
            {
                var user = UserPrincipal.FindByIdentity(ctx, userId.ToString());
                return user == null ? null : Task.FromResult(user.AsUser());
            }
        }

        public Task<User> GetUser(string userName)
        {
            using (var ctx = _directoryContext.LoadAndConnect())
            {
                var user = UserPrincipal.FindByIdentity(ctx, userName);
                return user == null ? null : Task.FromResult(user.AsUser());
            }
        }
    }
}

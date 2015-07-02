using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using E203.uManage.Directory;
using E203.uManage.Services.Models;

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

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return Task.FromResult(default(IEnumerable<User>));
        }

        public Task<User> GetUser(Guid userId)
        {
            var user = new User { UserId = userId };
            return Task.FromResult(user);
        }

        public Task<User> GetUser(string userName)
        {
            using (var ctx = _directoryContext.LoadAndConnect())
            {
                var user = UserPrincipal.FindByIdentity(ctx, userName);
                return Task.FromResult(new User
                {
                    NtUserName = user.SamAccountName,
                    UserPrincipalName = user.UserPrincipalName
                });
            }
        }
    }
}

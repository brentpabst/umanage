using E203.uManage.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E203.uManage.Services.ActiveDirectory
{
    public class UserService: IUserService
    {
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
            var user = new User {NtUserName = userName};
            return Task.FromResult(user);
        }
    }
}

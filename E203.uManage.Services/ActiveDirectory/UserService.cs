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
            throw new NotImplementedException();
        }

        public Task<User> GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}

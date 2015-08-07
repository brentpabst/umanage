using E203.uManage.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E203.uManage.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(Guid userId);
        Task<User> GetUser(string userName);
    }
}

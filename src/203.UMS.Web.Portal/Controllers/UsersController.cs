using _203.UMS.Data.Interfaces;
using _203.UMS.Directory;
using _203.UMS.Models.Directory;
using AttributeRouting;
using AttributeRouting.Web.Http;
using System;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Http;

namespace _203.UMS.Web.UI.Controllers
{
    [RouteArea("api"), RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IDbUow _dbRepo;
        private readonly DirectoryUow _dirRepo;

        public UsersController(IDbUow uow)
        {
            _dbRepo = uow;
            var conf = new Config.Connections(_dbRepo);
            var settings = conf.GetDirectorySettings(true);
            _dirRepo = new DirectoryUow(settings);
        }

        [GET(""), HttpGet]
        public IQueryable<User> GetUsers()
        {
            return _dirRepo.Users.GetAll();
        }

        [GET("me"), HttpGet]
        public User GetCurrentUser()
        {
            return _dirRepo.Users.Get(HttpContext.Current.User.Identity.Name);
        }

        [POST("me"), HttpPost]
        public User PostCurrentUser(User user)
        {
            var u = GetCurrentUser();
            if (user.UserId != u.UserId)
                throw new SecurityException("You are attempting to update a user record that is not your own.");

            _dirRepo.Users.Update(user);
            return _dirRepo.Users.Get(user.UserId);
        }

        [GET("{id}"), HttpGet]
        public User GetUser(Guid id)
        {
            return _dirRepo.Users.Get(id);
        }

        [POST("{id}"), HttpPost]
        public User PostUser(User user)
        {
            _dirRepo.Users.Update(user);
            return _dirRepo.Users.Get(user.UserId);
        }

        [GET("{id}/account/enable"), HttpGet]
        public User Enable(Guid id)
        {
            if (!_dirRepo.Users.Enable(id))
                throw new Exception("Failed to enable the user.");
            return GetUser(id);
        }
        
        [GET("{id}/account/disable"), HttpGet]
        public User Disable(Guid id)
        {
            if (!_dirRepo.Users.Disable(id))
                throw new Exception("Failed to disable the user.");
            return GetUser(id);
        }

        // /users/{id}/account/unlock - Unlocks a user account

        // /users/{id}/password/expire - Forces a password to expire
        // /users/{id}/password/code - Generates a password reset code
        // /users/{id}/password/reset - Changes the user's password with a reset code
        // /users/{id}/password/change - Changes the user's password

        // /users/{id}/photo - Gets or Updates the specified user's photo
    }
}

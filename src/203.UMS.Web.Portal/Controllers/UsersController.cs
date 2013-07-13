using _203.UMS.Data.Interfaces;
using _203.UMS.Directory;
using _203.UMS.Models.Directory;
using AttributeRouting;
using AttributeRouting.Web.Http;
using System;
using System.Linq;
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

        // TODO: /users/ - Gets all users
        [GET(""), HttpGet]
        public IQueryable<User> GetUsers()
        {
            return _dirRepo.Users.GetAll();
        }

        // /users/me - Gets or Updates the current user
        [GET("me"), HttpGet]
        public User GetCurrentUser()
        {
            return _dirRepo.Users.Get(HttpContext.Current.User.Identity.Name);
        }

        [POST("me"), HttpPost]
        public User PostCurrentUser(User user)
        {
            throw new NotImplementedException();
        }

        // /users/{id} - Gets or updates the specified user

        [GET("{id}"), HttpGet]
        public User GetUser(string id)
        {
            return _dirRepo.Users.Get(id);
        }

        [POST("{id}"), HttpPost]
        public User PutUser(string id, [FromBody]User user)
        {
            throw new NotImplementedException();
        }

         // /users/{id}/account/enable - Enables a user account
         // /users/{id}/account/disable - Disables a user account
         // /users/{id}/account/lock - Locks a user account
         // /users/{id}/account/unlock - Unlocks a user account
         
         // /users/{id}/password/expire - Forces a password to expire
         // /users/{id}/password/code - Generates a password reset code
         // /users/{id}/password/reset - Changes the user's password with a reset code
         // /users/{id}/password/change - Changes the user's password
         
         // /users/{id}/photo - Gets or Updates the specified user's photo
    }
}

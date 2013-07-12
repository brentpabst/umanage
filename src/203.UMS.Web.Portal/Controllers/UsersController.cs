using _203.UMS.Data.Contracts;
using _203.UMS.Directory;
using _203.UMS.Models.Config;
using _203.UMS.Models.Directory;
using AttributeRouting;
using AttributeRouting.Web.Http;
using System.Web;
using System.Web.Http;

namespace _203.UMS.Web.UI.Controllers
{
    [RouteArea("api"), RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IRepoUow _repo;
        private readonly DirectorySetting _settings;

        public UsersController(IRepoUow uow)
        {
            _repo = uow;
            var conf = new Config.Connections(_repo);
            _settings = conf.GetDirectorySettings(true);
        }

        // TODO: /users/ - Gets all users

        // /users/me - Gets or Updates the current user
        [GET("me"), HttpGet]
        public User GetCurrentUser()
        {
            var u = new UserRepository(_settings);
            return u.Find(HttpContext.Current.User.Identity.Name);
        }

        [POST("me"), HttpPost]
        public User PostCurrentUser(User user)
        {
            var u = new UserRepository(_settings);
            u.InsertOrUpdate(user);
            return u.Find(user.UserName);
        }

        // /users/{id} - Gets or updates the specified user

        [GET("{id}"), HttpGet]
        public User GetUser(string id)
        {
            var u = new UserRepository(_settings);
            return u.Find(id);
        }

        [POST("{id}"), HttpPost]
        public User PutUser(string id, [FromBody]User user)
        {
            var u = new UserRepository(_settings);
            u.InsertOrUpdate(user);
            return u.Find(user.UserName);
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

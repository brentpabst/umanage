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
    [RouteArea("api"), RoutePrefix("user")]
    public class UserController : ApiController
    {
        private readonly IRepoUow _repo;
        private readonly DirectorySetting _settings;

        public UserController(IRepoUow uow)
        {
            _repo = uow;
            var conf = new Config.Connections(_repo);
            _settings = conf.GetDirectorySettings(true);
        }

        [GET(""), HttpGet]
        public User GetUser()
        {
            var u = new UserRepository(_settings);
            return u.Find(HttpContext.Current.User.Identity.Name);
        }

        [PUT(""), HttpPut]
        public User PutUser(User user)
        {
            return user;
        }
    }
}

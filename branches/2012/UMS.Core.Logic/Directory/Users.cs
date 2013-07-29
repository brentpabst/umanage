using System.Web;
using UMS.Core.Data.Models.Config;
using UMS.Core.Data.Models.Directory;
using UMS.Core.Directory;

namespace UMS.Core.Logic.Directory
{
    public class Users
    {
        private readonly DirectorySetting _settings;

        public Users()
        {
            var conf = new Config.Connections();
            _settings = conf.GetDirectorySettings(true);
        }

        public User GetUser()
        {
            var u = new UserRepository(_settings);
            return u.Find(HttpContext.Current.User.Identity.Name);
        }
    }
}

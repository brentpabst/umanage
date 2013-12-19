using _203.UMS.Data.Interfaces;
using _203.UMS.Directory;
using _203.UMS.Models.Config;
using _203.UMS.Web.Config;
using System;
using System.Web.Http;

namespace _203.UMS.Web.UI.Controllers
{
    [RoutePrefix("api/system")]
    public class SystemController : ApiController
    {
        private readonly Connections _conn;
        private readonly DirectoryUow _dirRepo;


        public SystemController(IDbUow uow)
        {
            _conn = new Config.Connections(uow);
            var settings = _conn.GetDirectorySettings(true);
            _dirRepo = new DirectoryUow(settings);
        }

        [Route("directory"), HttpPost]
        public void ConfigureDirectory(DirectorySettings settings)
        {
            if (!_conn.SetDirectorySettings(settings))
                throw new Exception("Failed to save directory settings");
        }
    }
}

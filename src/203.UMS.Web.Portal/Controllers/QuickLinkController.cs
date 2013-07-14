using _203.UMS.Data.Interfaces;
using _203.UMS.Models.App;
using _203.UMS.Web.Config;
using AttributeRouting;
using AttributeRouting.Web.Http;
using System.Linq;
using System.Web.Http;

namespace _203.UMS.Web.UI.Controllers
{
    [RouteArea("api"), RoutePrefix("links")]
    public class QuickLinkController : ApiController
    {
        private readonly IDbUow _dbRepo;
        private readonly Settings _settings;
        public QuickLinkController(IDbUow uow)
        {
            _dbRepo = uow;
            _settings = new Settings(uow);
        }

        [GET(""), HttpGet]
        public IQueryable<QuickLink> GetAll()
        {
            return _dbRepo.QuickLinks.GetAll().OrderBy(q => q.DisplayOrder);
        }
    }
}

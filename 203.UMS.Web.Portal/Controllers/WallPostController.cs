using _203.UMS.Data.Interfaces;
using _203.UMS.Models.App;
using _203.UMS.Web.Config;
using AttributeRouting;
using AttributeRouting.Web.Http;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Http;
using System.Xml;

namespace _203.UMS.Web.UI.Controllers
{
    [RouteArea("api"), RoutePrefix("posts")]
    public class WallPostController : ApiController
    {
        private readonly IDbUow _dbRepo;
        private readonly Settings _settings;
        public WallPostController(IDbUow uow)
        {
            _dbRepo = uow;
            _settings = new Settings(uow);
        }

        [GET(""), HttpGet]
        public IQueryable<WallPost> GetAll()
        {
            var overidePosts = _settings.Get<bool>("OverrideWallPosts");
            if (!overidePosts)
            {
                return _dbRepo.WallPosts.GetAll().Where(p => p.IsDraft == false).OrderByDescending(p => p.PublishDate);
            }

            var rssFeed = _settings.Get<string>("WallPostRssUrl");
            var reader = XmlReader.Create(rssFeed);
            var feed = SyndicationFeed.Load(reader);

            if (feed == null) return null;
            var posts = feed.Items
                            .OrderByDescending(f => f.PublishDate.UtcDateTime)
                            .Select(a => new WallPost
                                {
                                    Title = a.Title.Text,
                                    PublishDate = a.PublishDate.UtcDateTime,
                                    Body = a.Content == null ? a.Summary.Text : a.Content.ToString()
                                })
                            .AsQueryable();
            return posts;
        }
    }
}

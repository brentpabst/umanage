using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;
using UMS.Core.Data.Models.App;
using UMS.Web.ViewModels;
using UMS.Core.Data.Repository;
using UMS.Core.Logic.Config;

namespace UMS.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public ActionResult Dashboard()
        {
            var m = new Dashboard();
            var repoW = new WallPostRepository();
            var repoL = new QuickLinkRepository();

            m.DisplayWeather = Settings.Get<bool>("EnableWeather");
            m.WeatherApiKey = Settings.Get<string>("WeatherApiKey");

            var wallOverride = Settings.Get<bool>("OverrideWallPosts");
            var wallUrl = Settings.Get<string>("WallPostRssUrl");

            if (wallOverride)
            {
                try
                {
                    var reader = XmlReader.Create(wallUrl);
                    var feed = SyndicationFeed.Load(reader);
                    m.WallPosts = feed.Items.Select(i => new WallPost
                                                           {
                                                               Title = i.Title.Text,
                                                               PublishDate = i.PublishDate.Date,
                                                               Body = i.Summary == null
                                                                    ? ""
                                                                    : i.Summary.Text
                                                           }).AsQueryable();
                }
                catch
                {
                    m.WallPosts = new List<WallPost>
                                      {
                                          new WallPost
                                              {
                                                  Title = "Error Loading RSS Feed",
                                                  PublishDate = DateTime.Now,
                                                  Body = "Unable to load the optional RSS feed.  Please check the configuration or try again later."
                                              }
                                      }.AsQueryable();
                }
            }
            else m.WallPosts = repoW.All.Where(p => !p.IsDraft && p.PublishDate <= DateTime.Today);

            m.QuickLinks = repoL.All.ToList();

            return View(m);
        }
    }
}

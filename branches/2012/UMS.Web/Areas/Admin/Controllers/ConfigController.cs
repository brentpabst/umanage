using System;
using System.Web;
using System.Web.Mvc;
using UMS.Core.Data.Models.Config;
using UMS.Core.Data.Models.Directory;
using UMS.Core.Data.Repository;
using UMS.Core.Logic.Config;
using UMS.Web.ViewModels;
using UMS.Core.Logic.Directory;

namespace UMS.Web.Areas.Admin.Controllers
{
    public class ConfigController : Controller
    {
        //
        // GET: /Config/
        public ActionResult Index()
        {
            return View("Summary");
        }

        public ActionResult Summary()
        {
            return View();
        }

        public ActionResult Directory()
        {
            var dir = new Connections().GetDirectorySettings();
            return View(dir);
        }

        [HttpPost]
        public ActionResult Directory(DirectorySetting dir)
        {
            if (ModelState.IsValid)
            {
                var c = new Connections();
                c.SetDirectorySettings(dir);

                return RedirectToAction("Directory");
            }

            ViewData["Result"] = new HtmlString("<span class=\"failure\">Failed! The data provided was not valid.</span>");
            return View();
        }

        public ActionResult Database()
        {
            var db = new Connections().GetDatabaseSettings();
            return View(db);
        }

        public ActionResult Groups()
        {
            ViewData["Groups"] = Settings.Get<string>("GroupsToIgnore");
            return View();
        }

        [HttpPost]
        public ActionResult Groups(string groups)
        {
            try
            {
                Settings.Put("GroupsToIgnore", groups);
                return RedirectToAction("Groups");
            }
            catch (Exception)
            {
                ViewData["Result"] = new HtmlString("<span class=\"failure\">Failed! Could not save the groups.</span>");
                return View();
            }
        }

        public ActionResult Offline()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Offline(OfflineSetting offline)
        {
            if (ModelState.IsValid)
            {
                var s = new Core.Logic.Config.System();
                s.TakeOffline(offline.Message);

                return RedirectToAction("Offline");
            }

            ViewData["Result"] = new HtmlString("<span class=\"failure\">Failed! Input was not valid.</span>");
            return View();
        }

        public ActionResult Home()
        {
            var s = new HomeSettings
                        {
                            WeatherSetting =
                                {
                                    IsEnabled = Settings.Get<bool>("EnableWeather"),
                                    ApiKey = Settings.Get<string>("WeatherApiKey")
                                },
                            WallPostSetting =
                                {
                                    IsOverrideEnabled = Settings.Get<bool>("OverrideWallPosts"),
                                    RssOverrideUrl = Settings.Get<string>("WallPostRssUrl")
                                }
                        };

            return View(s);
        }

        [HttpPost]
        public ActionResult Home(HomeSettings settings)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Settings.Put("EnableWeather", settings.WeatherSetting.IsEnabled);
                    Settings.Put("WeatherApiKey", String.IsNullOrWhiteSpace(settings.WeatherSetting.ApiKey) ? "" : settings.WeatherSetting.ApiKey);
                    Settings.Put("OverrideWallPosts", settings.WallPostSetting.IsOverrideEnabled);
                    Settings.Put("WallPostRssUrl", String.IsNullOrWhiteSpace(settings.WallPostSetting.RssOverrideUrl) ? "" : settings.WallPostSetting.RssOverrideUrl);
                    return RedirectToAction("Home");
                }
                catch (Exception ex)
                {
                    ViewData["Result"] = new HtmlString("<span class=\"failure\">Failed! Could not save all settings</span>");
                }
                return View();
            }
            ViewData["Result"] = new HtmlString("<span class=\"failure\">Failed! Input was not valid.</span>");
            return View();
        }

        public ActionResult PasswordReminder()
        {
            var p = new PasswordReminder();
            return View(Core.Logic.Directory.PasswordReminder.GetSettings());
        }

        [HttpPost]
        public ActionResult PasswordReminder(PasswordReminderSetting settings)
        {
            var p = new PasswordReminder();
            var r = Core.Logic.Directory.PasswordReminder.UpdateSettings(settings);
            if (r)
            {
                ViewData["Result"] = new HtmlString("<span class=\"ok\">Success! Saved the changes.</span>");
            }
            else
            {
                ViewData["Result"] = new HtmlString("<span class=\"failure\">Failed! Could not save all settings</span>");
            }
            return View(Core.Logic.Directory.PasswordReminder.GetSettings());
        }
    }
}

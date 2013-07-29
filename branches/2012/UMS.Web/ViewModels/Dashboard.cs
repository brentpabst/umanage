using System.Collections.Generic;
using System.Linq;
using UMS.Core.Data.Models.App;

namespace UMS.Web.ViewModels
{
    public class Dashboard
    {
        public IQueryable<WallPost> WallPosts { get; set; }
        public List<QuickLink> QuickLinks { get; set; }
        public bool DisplayWeather { get; set; }
        public string WeatherApiKey { get; set; }
        public bool OverrideWallPosts { get; set; }
    }
}
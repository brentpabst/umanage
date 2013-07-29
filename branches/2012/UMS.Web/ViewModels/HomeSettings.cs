using UMS.Core.Data.Models.Config;

namespace UMS.Web.ViewModels
{
    public class HomeSettings
    {
        public HomeSettings()
        {
            WeatherSetting = new WeatherSetting();
            WallPostSetting = new WallPostSetting();
        }

        public WeatherSetting WeatherSetting { get; set; }
        public WallPostSetting WallPostSetting { get; set; }
    }
}
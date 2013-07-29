using System.Web.Mvc;

namespace UMS.Web.Areas.Admin
{
    public class ConfigAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Config", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

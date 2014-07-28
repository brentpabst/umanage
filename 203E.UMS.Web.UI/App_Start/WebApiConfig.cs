using System.Web.Http;

namespace E203.UMS.Web.UI
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}
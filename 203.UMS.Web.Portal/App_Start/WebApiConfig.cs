using System.Web.Http;
using _203.UMS.Web.Filters;

namespace _203.UMS.Web.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            //config.EnableSystemDiagnosticsTracing();

            config.Filters.Add(new UmsExceptionFilter());
            config.Filters.Add(new ValidateModelFilter());
        }
    }
}
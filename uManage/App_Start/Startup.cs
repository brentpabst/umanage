using System.Web.Http;
using Owin;

namespace uManage
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            
            // Wire up the routes
            config.MapHttpAttributeRoutes();

            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            appBuilder.UseWebApi(config);
        }
    }
}

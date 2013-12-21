using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _203.UMS.Web.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

#if DEBUG
            // Remove XML
            // We test against JSON for simplicity, Web API Should provide XML properly if the caller wants it
            var matches = config.Formatters
                           .Where(f => f.SupportedMediaTypes.Any(m => m.MediaType.ToString() == "application/xml" ||
                                                                      m.MediaType.ToString() == "text/xml"))
                           .ToList();
            foreach (var match in matches)
                config.Formatters.Remove(match);
#endif

            // JSON Settings
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            if (HttpContext.Current.IsDebuggingEnabled)
                json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            
        }
    }
}
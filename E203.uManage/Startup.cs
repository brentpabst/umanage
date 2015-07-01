using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Net;
using System.Web.Http;

namespace E203.uManage
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
#if DEBUG
            appBuilder.UseErrorPage();
#endif

            var config = new HttpConfiguration();

            // Enable Windows Auth
            var listener = (HttpListener)appBuilder.Properties[typeof(HttpListener).FullName];
            listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;

            // Enable CORS support
            appBuilder.UseCors(CorsOptions.AllowAll);

            // Disable XML support
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Pretty JSON
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

#if DEBUG
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
#endif

            // Default Router
            config.MapHttpAttributeRoutes();

            // Load Static Files
            appBuilder.UseFileServer(new FileServerOptions()
            {
                RequestPath = PathString.Empty,
                FileSystem = new PhysicalFileSystem(@".\Web")
            });

            // Endable Ninject
            appBuilder.UseNinjectMiddleware(DependencyConfig.CreateKernel);
            appBuilder.UseNinjectWebApi(config);

            appBuilder.UseWebApi(config);
        }
    }
}

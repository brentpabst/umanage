using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.Net;
using System.Web.Http;

namespace uManage
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
#if DEBUG
            appBuilder.UseErrorPage();
#endif

            // Setup Windows Auth
            var listener = (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
            listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
            
            // Build a config
            var config = new HttpConfiguration();

            // Wire up dependency injection
            config.DependencyResolver = new NinjectResolver(NinjectConfig.CreateKernel());

            // Wire up the routes
            config.MapHttpAttributeRoutes();

            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Activate the API
            appBuilder.UseWebApi(config);

            // Show static files
            appBuilder.UseStaticFiles("/scripts");
            appBuilder.UseStaticFiles("/content");
            appBuilder.UseStaticFiles("/fonts");
            appBuilder.UseStaticFiles("/app");
            appBuilder.UseFileServer(new FileServerOptions()
            {
                RequestPath = PathString.Empty,
                FileSystem = new PhysicalFileSystem(@".\Index")
            });
        }
    }
}

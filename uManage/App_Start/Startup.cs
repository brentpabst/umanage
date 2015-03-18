using System.IO;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.Net;
using System.Web.Http;
using Swashbuckle.Application;

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

            // Enable Swagger
            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase); ;
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "uManage Api");
                    c.IgnoreObsoleteActions();
                    c.IgnoreObsoleteProperties();
                    c.DescribeAllEnumsAsStrings();
                    c.IncludeXmlComments(appPath + @"\uManage.xml");
                    c.IncludeXmlComments(appPath + @"\uManage.Models.xml");
                    c.IncludeXmlComments(appPath + @"\uManage.Directories.xml");
                })
                .EnableSwaggerUi();

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

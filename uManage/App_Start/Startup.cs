using System.IO;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;

namespace uManage
{
    /// <summary>
    /// Application Startup Configuration
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration for the specified application builder.
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
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

            // Setup JSON settings
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

#if DEBUG
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
#endif

            // Enable Swagger
            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
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

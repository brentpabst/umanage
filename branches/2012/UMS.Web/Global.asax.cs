using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UMS.Core.Data;
using UMS.Core.Logic.Directory;

namespace UMS.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public static readonly Version Version = Assembly.GetExecutingAssembly().GetName().Version;

        protected void Application_Start()
        {
            Database.SetInitializer(new SystemInit());

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            var u = new Users();
            Session["User"] = u.GetUser();
        }
    }
}
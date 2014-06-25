using _203.UMS.Web.Filters;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace _203.UMS.Web.UI
{
    public class FilterConfig
    {
        internal static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // MVC Filters
            filters.Add(new HandleErrorAttribute());
        }

        internal static void RegisterHttpFilters(HttpFilterCollection filters)
        {
            // Web API Filters
            filters.Add(new UmsExceptionFilter());
            filters.Add(new ValidateModelFilter());
        }
    }
}

using _203.UMS.Web.Filters;
using System.Web.Mvc;

namespace _203.UMS.Web.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new UmsExceptionFilter());
            filters.Add(new ValidateModelFilter());
        }
    }
}
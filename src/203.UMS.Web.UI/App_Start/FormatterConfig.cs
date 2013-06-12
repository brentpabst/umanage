using _203.UMS.Web.Formatter;
using System.Web;
using System.Web.Http;

namespace _203.UMS.Web.UI
{
    public class FormatterConfig
    {
        public static void RegisterFormatters(HttpConfiguration config)
        {
            if (HttpContext.Current.IsDebuggingEnabled)
                config.Formatters.Clear();

            config.Formatters.Insert(0, new JsonpMediaTypeFormatter());
        }
    }
}
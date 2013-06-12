using AttributeRouting;
using AttributeRouting.Web.Http;
using System.Web;
using System.Web.Http;

namespace _203.UMS.Web.UI.Controllers
{
    [RouteArea("api"), RoutePrefix("employee")]
    public class EmployeeController : ApiController
    {
        [GET(""), HttpGet]
        public string GetEmployee()
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }
}

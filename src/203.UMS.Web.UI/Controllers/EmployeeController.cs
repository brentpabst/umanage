using AttributeRouting;
using AttributeRouting.Web.Http;
using System.Web;
using System.Web.Http;
using _203.UMS.Models;

namespace _203.UMS.Web.UI.Controllers
{
    [RouteArea("api"), RoutePrefix("employee")]
    public class EmployeeController : ApiController
    {
        [GET(""), HttpGet]
        public Employee GetEmployee()
        {
            return new Employee
                {
                    Username = HttpContext.Current.User.Identity.Name
                };
        }
    }
}

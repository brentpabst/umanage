using System.Web;
using System.Web.Http;

namespace uManage.Controllers
{
    [RoutePrefix("api/heartbeat")]
    public class HeartbeatController : ApiController
    {
        [Route("")]
        public string Get()
        {
            var response = "API OK. Hello " + RequestContext.Principal.Identity.Name;
            return response;
        }
    }
}

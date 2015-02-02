using System.Web.Http;

namespace uManage.Controllers
{
    [RoutePrefix("api/heartbeat")]
    public class HeartbeatController : ApiController
    {
        [Route("")]
        public string Get()
        {
            return "API OK";
        }
    }
}

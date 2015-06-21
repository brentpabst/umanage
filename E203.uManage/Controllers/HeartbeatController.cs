using System.Web.Http;

namespace E203.uManage.Controllers
{
    [RoutePrefix("heartbeat")]
    public class HeartbeatController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult Heartbeat()
        {
            return Ok(StartupArt.Logo);
        }
    }
}

using System.Web.Http;

namespace uManage.Controllers
{
    /// <summary>
    /// Heartbeat Controller
    /// </summary>
    [RoutePrefix("api/heartbeat")]
    public class HeartbeatController : ApiController
    {
        /// <summary>
        /// Provides a heartbeat monitoring endpoint.
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public string Get()
        {
            var response = "API OK. Hello " + RequestContext.Principal.Identity.Name;
            return response;
        }
    }
}

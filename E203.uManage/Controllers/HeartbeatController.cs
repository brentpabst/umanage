using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace E203.uManage.Controllers
{
    [RoutePrefix("heartbeat")]
    public class HeartbeatController : ApiController
    {
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> Heartbeat()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Art.Logo, Encoding.ASCII, "text/plain")
            };
            return await Task.FromResult(response);
        }
    }
}

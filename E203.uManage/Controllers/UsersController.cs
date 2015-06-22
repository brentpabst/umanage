using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace E203.uManage.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController:ApiController
    {
        [Route("me")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}

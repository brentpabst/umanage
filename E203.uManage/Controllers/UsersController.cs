using E203.uManage.Services;
using E203.uManage.Services.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace E203.uManage.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            if (_userService == null)
                _userService = userService;
        }

        [Route("me")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetCurrentUser()
        {
            var currentUser = Request.GetOwinContext().Authentication.User.Identity.Name; // TODO: Replace this with a base api controller thingamajig
            var user = await _userService.GetUser(currentUser);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}

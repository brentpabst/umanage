using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using S203.uManage.Services;
using S203.uManage.Services.Models;

namespace S203.uManage.Controllers
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

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers(); //TODO: This is horribly slow based on testing (750 users returned)

            if (users == null)
                return NotFound();

            return Ok(users);
        }

        [Route("me")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetCurrentUser()
        {
            var user = await _userService.GetUser(CurrentUser.Identity.Name);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Route("{id:guid}")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}

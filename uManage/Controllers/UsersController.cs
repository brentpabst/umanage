using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using uManage.Directories;
using uManage.Models;

namespace uManage.Controllers
{
    /// <summary>
    /// User Api Controller
    /// </summary>
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IDirectoryService _dir;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="dir">The dir.</param>
        public UsersController(IDirectoryService dir)
        {
            if (_dir == null)
                _dir = dir;
        }

        /// <summary>
        /// Get a list of users.
        /// </summary>
        /// <returns></returns>
        [Route(""), HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public async Task<IHttpActionResult> GetUsers()
        {
            var result = await _dir.Users.GetAllUsers();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns></returns>
        [Route("me"), HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetCurrentUser()
        {
            var result = await _dir.Users.GetUser(RequestContext.Principal.Identity.Name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Updates the current user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("me"), HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> UpdateCurrentUser(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the current user's photo.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("me/photo"), HttpGet]
        public async Task<IHttpActionResult> GetCurrentUserPhoto()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the current user's photo.
        /// </summary>
        /// <param name="photo">The photo to update.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("me/photo"), HttpPost]
        public async Task<IHttpActionResult> UpdateCurrentUserPhoto(byte[] photo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        [Route("{id}"), HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="user">The user to update.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("{id}"), HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> UpdateUser(Guid id, User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a user's photo.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("{id}/photo"), HttpGet]
        public async Task<IHttpActionResult> GetUserPhoto(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a user's photo.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="photo">The photo.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("{id}/photo"), HttpPost]
        public async Task<IHttpActionResult> UpdateUserPhoto(Guid id, byte[] photo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Enables a user account.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("{id}/account/enable"), HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> EnableAccount(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disables a user account.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("{id}/account/disable"), HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DisableAccount(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unlocks a user account.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("{id}/account/unlock"), HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> UnlockAccount(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Expires a user's password.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [Route("{id}/password/expire"), HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> ExpirePassword(Guid id)
        {
            throw new NotImplementedException();
        }

        // TODO: GET    /users/{id}/password/code       Generates a password reset code
        // TODO: POST   /users/{id}/password/reset      Changes the user's password with a reset code
        // TODO: POST   /users/{id}/password/change     Changes the user's password
    }
}

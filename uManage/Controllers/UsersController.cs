using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using uManage.Directories;
using uManage.Models;

namespace uManage.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IDirectoryService _dir;

        public UsersController(IDirectoryService dir)
        {
            if (_dir == null)
                _dir = dir;
        }

        [Route(""), HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _dir.Users.GetAllUsers();
        }

        [Route("me"), HttpGet]
        public User GetCurrentUser()
        {
            return _dir.Users.GetUser(RequestContext.Principal.Identity.Name);
        }

        [Route("me"), HttpPost]
        public User UpdateCurrentUser(User user)
        {
            throw new NotImplementedException();
        }

        [Route("me/photo"), HttpGet]
        public HttpResponseMessage GetCurrentUserPhoto()
        {
            throw new NotImplementedException();
        }

        [Route("me/photo"), HttpPost]
        public HttpResponseMessage UpdateCurrentUserPhoto(byte[] photo)
        {
            throw new NotImplementedException();
        }

        [Route("{id}"), HttpGet]
        public User GetUser(Guid id)
        {
            return _dir.Users.GetUser(id);
        }

        [Route("{id}"), HttpPost]
        public User UpdateUser(Guid id, User user)
        {
            throw new NotImplementedException();
        }

        [Route("{id}/photo"), HttpGet]
        public HttpResponseMessage GetUserPhoto(Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("{id}/photo"), HttpPost]
        public HttpResponseMessage UpdateUserPhoto(Guid id, byte[] photo)
        {
            throw new NotImplementedException();
        }

        [Route("{id}/account/enable"), HttpPost]
        public HttpResponseMessage EnableAccount(Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("{id}/account/disable"), HttpPost]
        public HttpResponseMessage DisableAccount(Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("{id}/account/unlock"), HttpPost]
        public HttpResponseMessage UnlockAccount(Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("{id}/password/expire"), HttpPost]
        public HttpResponseMessage ExpirePassword(Guid id)
        {
            throw new NotImplementedException();
        }

        // TODO: GET    /users/{id}/password/code       Generates a password reset code
        // TODO: POST   /users/{id}/password/reset      Changes the user's password with a reset code
        // TODO: POST   /users/{id}/password/change     Changes the user's password
    }
}

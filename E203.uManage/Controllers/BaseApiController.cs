using NLog;
using System;
using System.Net.Http;
using System.Security;
using System.Security.Claims;
using System.Web.Http;

namespace E203.uManage.Controllers
{
    public class BaseApiController : ApiController
    {
        public Logger SystemLogger = LogManager.GetLogger("uManage");

        public ClaimsPrincipal CurrentUser
        {
            get
            {
                var owinRequest = Request.GetOwinContext();
                if (owinRequest == null)
                    throw new Exception("OWIN Context is null.");

                var user = owinRequest.Authentication.User;
                if (user == null)
                    throw new SecurityException("User Principal is null.");

                return user;
            }
        }
    }
}

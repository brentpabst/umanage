using System;
using System.Net.Http;
using System.Security;
using System.Security.Claims;
using System.Web.Http;
using NLog;

namespace S203.uManage.Controllers
{
    public class BaseApiController : ApiController
    {
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

        internal Logger SystemLogger = LogManager.GetLogger("uManage");
    }
}

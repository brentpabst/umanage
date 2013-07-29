using System;
using System.Net;
using System.Web.Mvc;

namespace UMS.Web.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View(Server.GetLastError());
        }

        public ActionResult ServerError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }

        public ActionResult ThrowError()
        {
            throw new NotImplementedException("By Design: This is a test method only.");
        }
    }
}

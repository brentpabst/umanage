using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace _203.UMS.Web.Filters
{
    public class UmsExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // Not Implemented Exception
            if (actionExecutedContext.Exception is NotImplementedException)
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }
    }
}

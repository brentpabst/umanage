using NLog;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace E203.uManage.Handlers
{
    public class ApiLoggingHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Get the OWIN request
            var owinRequest = request.GetOwinContext();
            if (owinRequest == null)
                throw new Exception("OWIN Context is null.");

            // Spin up logging
            var logger = LogManager.GetLogger("uManage");
            logger.Debug("{{ \"apiRequest\": {{ \"request\": \"{0} {1}\", \"user\": \"{2}\", \"ipAddress\": \"{3}\" }}}}",
                request.Method.Method,
                request.RequestUri.PathAndQuery.ToLower(),
                owinRequest.Authentication.User.Identity.Name.ToLower(),
                owinRequest.Request.RemoteIpAddress);

            // Time the request/process time for logging purposes
            var stopwatch = Stopwatch.StartNew();

            // Run the request
            var response = await base.SendAsync(request, cancellationToken);

            // Log the request complete time and time taken
            stopwatch.Stop();
            logger.Debug("{{ \"apiRequestComplete\": {{ \"request\": \"{0} {1}\", \"user\": \"{2}\", \"ipAddress\": \"{3}\", \"timeTaken\": \"{4}ms\" }}}}",
                request.Method.Method,
                request.RequestUri.PathAndQuery.ToLower(),
                owinRequest.Authentication.User.Identity.Name.ToLower(),
                owinRequest.Request.RemoteIpAddress,
                stopwatch.ElapsedMilliseconds);

            return response;
        }
    }
}

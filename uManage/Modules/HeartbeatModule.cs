using Nancy;

namespace uManage.Modules
{
    public class HeartbeatModule : NancyModule
    {
        public HeartbeatModule()
            : base("/api")
        {
            Get["/heartbeat"] = _ => new Response
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = "API OK"
                };
        }
    }
}

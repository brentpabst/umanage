using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using S203.uManage.Services.Extensions;

namespace S203.uManage.Controllers
{
    [RoutePrefix("api")]
    public class ApiInfoController : BaseApiController
    {
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(ApiModel))]
        public async Task<IHttpActionResult> GetAllApis()
        {
            return await Task.Run(() =>
            {
                var apiExplorer = Configuration.Services.GetApiExplorer();

                var apiModel = new ApiModel
                {
                    Application = "uManage" + " v" + Assembly.GetExecutingAssembly().GetName().Version.Major,
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                    User = CurrentUser.Identity.Name,
                    Links = new Dictionary<string, string>()
                };

                foreach (var api in apiExplorer.ApiDescriptions)
                {
                    apiModel.Links.Add(api.ActionDescriptor.ActionName, api.HttpMethod + " " + api.RelativePath);
                }

                return Ok(apiModel);
            });
        }

        public class ApiModel
        {
            public string Application { get; set; }
            public string Version { get; set; }
            public string User { get; set; }
            public Dictionary<string, string> Links { get; set; }
        }
    }
}

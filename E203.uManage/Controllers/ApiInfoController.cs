using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace S203.uManage.Controllers
{
    [RoutePrefix("api")]
    public class ApiInfoController : BaseApiController
    {
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(List<ApiModel>))]
        public async Task<IHttpActionResult> GetAllApis()
        {
            IApiExplorer apiExplorer = Configuration.Services.GetApiExplorer(); ;

            return await Task.Run(() =>
            {
                var apiModel = new ApiModel
                {
                    Application = "uManage",
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                    Links = new Dictionary<string, string>()
                };

                foreach (var api in apiExplorer.ApiDescriptions)
                {
                    apiModel.Links.Add(api.ActionDescriptor.ActionName, api.RelativePath);
                }

                return Ok(apiModel);
            });
        }

        internal class ApiModel
        {
            internal string Application { get; set; }
            internal string Version { get; set; }
            internal Dictionary<string, string> Links { get; set; }
        }
    }
}

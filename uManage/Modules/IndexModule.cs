using Nancy;
using Nancy.Linker;

namespace uManage.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule(IResourceLinker linker)
        {
            Get["/"] = _ => Response.AsRedirect(linker.BuildAbsoluteUri(Context, "EntryPoint").ToString());
            Get["EntryPoint", "/app"] = _ => View["index.html"];
        }
    }
}

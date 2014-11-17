using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using SquishIt.Framework;

namespace uManage
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.AddDirectory("content");
            conventions.StaticContentsConventions.AddDirectory("scripts");
            conventions.StaticContentsConventions.AddDirectory("fonts");
            conventions.StaticContentsConventions.AddDirectory("app");
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            Nancy.Security.Csrf.Enable(pipelines);

            pipelines.BeforeRequest += (ctx) =>
            {
                ctx.ViewBag.Styles = Bundle.Css().RenderCachedAssetTag("styles");
                ctx.ViewBag.Scripts = Bundle.JavaScript().RenderNamed("scripts");
                return null;
            };

            Bundle.Css()
                .Add("~/content/bootstrap.css")
                .Add("~/content/bootstrap-theme.css")
                .Add("~/content/font-awesome.css")
                .Add("~/content/site.less")
                .AsCached("styles", "/content/styles.css");

            Bundle.JavaScript()
                .AsNamed("scripts", "/content/scripts.js");
        }
    }
}

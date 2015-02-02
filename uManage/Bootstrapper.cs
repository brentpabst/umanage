using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;

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
                return null;
            };
        }
    }
}

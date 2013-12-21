using System;
using System.Web.Optimization;

namespace _203.UMS.Web.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(
                new ScriptBundle("~/scripts/modernizr")
                    .Include("~/scripts/modernizr-{version}.js"));

            bundles.Add(
              new ScriptBundle("~/scripts/vendor")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/knockout-{version}.js")
                .Include("~/Scripts/moment.js")
            );

            bundles.Add(
             new StyleBundle("~/styles/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/durandal.css")
             );

            // Site
            var site = new Bundle("~/styles/ums")
                .Include("~/Content/ums.less");
            site.Transforms.Add(new LessTransform());
            site.Transforms.Add(new CssMinify());
            bundles.Add(site);
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }

        public class LessTransform : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse response)
            {
                response.Content = dotless.Core.Less.Parse(response.Content);
                response.ContentType = "text/css";
            }
        }
    }
}
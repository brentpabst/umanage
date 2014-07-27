using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace E203.UMS.Web.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);
            
            bundles.Add(
                new ScriptBundle("~/scripts/bcsupport").Include(
                    "~/scripts/modernizr-{version}.js",
                    "~/Scripts/respond.js"));

            bundles.Add(
              new ScriptBundle("~/scripts/vendor").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/moment.js",
                "~/Scripts/moment-timezone.js",
                "~/Scripts/moment-with-langs.js"));

            bundles.Add(
             new StyleBundle("~/styles/vendor").Include(
                "~/Content/bootstrap.css",
                "~/Content/durandal.css",
                "~/Content/font-awesome.css"));

            var site = new Bundle("~/styles/site")
                .Include("~/Content/site.less");
            site.Transforms.Add(new LessTransform());
            site.Transforms.Add(new CssMinify());
            bundles.Add(site);
        }

        private static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
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

        private class LessTransform : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse response)
            {
                response.Content = dotless.Core.Less.Parse(response.Content);
                response.ContentType = "text/css";
            }
        }
    }
}
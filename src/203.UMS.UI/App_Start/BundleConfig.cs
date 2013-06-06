using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace _203.UMS.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Modernizr
            bundles.Add(new ScriptBundle("~/scripts/modernizr").Include("~/Scripts/modernizr-*"));

            // jQuery
            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                "~/Scripts/jquery-*"));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
                "~/Scripts/bootstrap.*"));
            bundles.Add(new StyleBundle("~/styles/bootstrap").Include(
                "~/Content/bootstrap.*"));

            // Site
            var site = new Bundle("~/styles/ums")
                .Include("~/Content/ums.less");
            site.Transforms.Add(new LessTransform());
            site.Transforms.Add(new CssMinify());
            bundles.Add(site);

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
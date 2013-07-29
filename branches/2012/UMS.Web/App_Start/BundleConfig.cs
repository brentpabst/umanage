using System.Web.Optimization;

namespace UMS.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.8.0.js",
                        "~/Scripts/jquery-1.8.0-vsdoc.js",
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery-ui*",
                        "~/Scripts/jquery.timeago.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/ums").Include(
                        "~/Scripts/ums.global.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                        "~/Scripts/tinymce/jquery.tinymce.js"));

            bundles.Add(new StyleBundle("~/bundles/css/reset").Include("~/Styles/Reset.css"));

            bundles.Add(new StyleBundle("~/bundles/css/jquery").Include(
                        "~/Styles/jquery.validation.inline.css",
                        "~/Styles/themes/base/jquery.ui.all.css"));

            bundles.Add(new StyleBundle("~/bundles/css").Include("~/Styles/Site/*.css"));
        }
    }
}
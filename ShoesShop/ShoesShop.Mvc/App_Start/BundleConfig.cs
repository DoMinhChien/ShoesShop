using System.Web.Optimization;

namespace ShoesShop.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/CSS/style.css",
                      "~/Content/CSS/responsive.css",
                      "~/Content/CSS/adminpro-custon-icon.css",
                      "~/Content/CSS/animate.css",
                      "~/Content/CSS/bootstrap-editable.css",
                      "~/Content/CSS/bootstrap-table.css",
                      "~/Content/CSS/bootstrap.min.css",
                      "~/Content/CSS/c3.min.css",
                      "~/Content/CSS/font-awesome.min.css",
                      "~/Content/CSS/jquery.mCustomScrollbar.min.css",
                      "~/Content/CSS/meanmenu.min.css",
                      "~/Content/CSS/normalize.css"
                      ));
        }
    }
}

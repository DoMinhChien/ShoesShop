using System.Web.Optimization;

namespace ShoesShop.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                        "~/Scripts/jquery-2.2.4.js",
                        "~/Scripts/jquery-2.2.4.min.js",
                        "~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap-table").Include(
                      "~/Scripts/data-table/bootstrap-table.js",
                      "~/Scripts/data-table/tableExport.js",
                      "~/Scripts/data-table/data-table-active.js",
                      "~/Scripts/data-table/bootstrap-table-editable.js",
                      "~/Scripts/data-table/bootstrap-editable.js"));
            bundles.Add(new ScriptBundle("~/Scripts/select2").Include(
                      "~/Scripts/select2/select2.full.min.js",
                      "~/Scripts/select2/select2-active.js"
                    ));
            bundles.Add(new ScriptBundle("~/Scripts/sweetalert2").Include(
          "~/Scripts/sweetalert2/sweetalert2.all.min.js",
          "~/Scripts/sweetalert2/sweetalert2.js",
          "~/Scripts/sweetalert2/sweetalert2.min.js"
        ));
            // Use the~/Scripts/data-table/colResizable-1.5.source.js">< development version of Modernizr to develop with and learn from. Then, when you're
            // ready f~/Scripts/data-table/bootstrap-table-export.js"></or production, use the build tool at https://modernizr.com to pick only the tests you need.
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
                      "~/Content/CSS/normalize.css",
                      "~/Content/CSS/buttons.css",
                      "~/Content/CSS/preloader-style.css",
                      "~/Content/CSS/select2.min.css"
                      ));
            bundles.Add(new ScriptBundle("~/Scripts/common").Include(
                      "~/Scripts/apps/Common/CommonGlobal.js",
                       "~/Scripts/apps/Common/CommonEnum.js",
                       "~/Scripts/moment/moment.js"));
        }
    }
}

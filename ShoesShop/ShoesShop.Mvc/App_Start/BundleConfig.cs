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
            bundles.Add(new ScriptBundle("~/Scripts/component").Include(
                  "~/Scripts/apps/component/DropDown.js",
                   "~/Scripts/apps/component/History.js",
                   "~/Scripts/apps/component/Input.js",
                   "~/Scripts/apps/component/NumberInput.js",
                   "~/Scripts/apps/component/SwitchStatus.js"));

            

            bundles.Add(new ScriptBundle("~/Scripts/common").Include(
                      "~/Scripts/apps/Common/CommonGlobal.js",
                      "~/Scripts/apps/Common/CommonEnum.js",
                      "~/Scripts/moment/moment.js",
                      "~/Content/User/vendor/select2/select2.min.js"));

            bundles.Add(new StyleBundle("~/Content/common").Include(
                      "~/Content/Admin/CSS/bootstrap.min.css",
                      "~/Content/Admin/CSS/animate.css",
                      "~/Content/Admin/CSS/font-awesome.min.css",
                      "~/Content/Admin/CSS/select2.min.css"));
            bundles.Add(new StyleBundle("~/Content/Admin").Include(
                      "~/Content/Admin/CSS/style.css",
                      "~/Content/Admin/CSS/responsive.css",
                      "~/Content/Admin/CSS/adminpro-custon-icon.css",
                      "~/Content/Admin/CSS/bootstrap-editable.css",
                      "~/Content/Admin/CSS/bootstrap-table.css",
                      "~/Content/Admin/CSS/c3.min.css",
                      "~/Content/Admin/CSS/font-awesome.min.css",
                      "~/Content/Admin/CSS/jquery.mCustomScrollbar.min.css",
                      "~/Content/Admin/CSS/meanmenu.min.css",
                      "~/Content/Admin/CSS/normalize.css",
                      "~/Content/Admin/CSS/buttons.css",
                      "~/Content/Admin/CSS/preloader-style.css",
                      "~/Content/Admin/CSS/KoGrid.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/User").Include(
                      "~/Content/User/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/User/fonts/iconic/css/material-design-iconic-font.min.css",
                      "~/Content/User/fonts/linearicons-v1.0.0/icon-font.min.css",
                      "~/Content/User/vendor/css-hamburgers/hamburgers.min.css",
                      "~/Content/User/vendor/animsition/css/animsition.min.css",
                      "~/Content/User/vendor/daterangepicker/daterangepicker.css",
                      "~/Content/User/vendor/slick/slick.css",
                      "~/Content/User/vendor/MagnificPopup/magnific-popup.css",
                      "~/Content/User/vendor/perfect-scrollbar/perfect-scrollbar.css",
                      "~/Content/User/css/util.css",
                      "~/Content/User/css/main.css"

                      ));

        }
    }
}

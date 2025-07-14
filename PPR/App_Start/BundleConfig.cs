using System.Web;
using System.Web.Optimization;

namespace PPR
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        /*"~/Scripts/jquery-3.4.1.min.js"*/
                        "~/Content/js/jquery.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
   "~/Content/css/bootstrap.min.css",
     "~/Content/css/bootstrap-responsive.min.css",
    "~/Content/css/colorpicker.css",
     "~/Content/css/datepicker.css",
     //"~/Content/css/select2.css",
     "~/Content/css/maruti-style.css",
    "~/Content/css/maruti-media.css",
  "~/Content/css/fullcalendar.css",
     "~/Content/css/uniform.css",
 "~/Content/css/toastr.min.css",
  "~/Content/css/font-awsome.css",
     "~/Content/css/sweetalert.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
    //"~/Content/js/jquery.min.js",

    "~/Content/js/bootstrap.min.js",


    "~/Content/js/bootstrap-colorpicker.js",
    //"~/Content/js/select2.min.js",
    "~/Content/js/maruti.js",
    "~/Content/js/maruti.form_common.js",
    //    "~/Content/js/maruti.dashboard.js",
    //      "~/Content/js/bootstrap-datepicker.js",
    //"~/Content/js/fullcalendar.min.js",
    "~/Content/js/excanvas.min.js",
    "~/Content/js/jquery.flot.min.js",
    "~/Content/js/jquery.flot.resize.min.js",
    "~/Content/js/jquery.peity.min.js",
    "~/Content/js/maruti.chat.js",
    "~/Content/js/jquery.uniform.js",
    "~/Content/js/jquery.dataTables.min.js",
    "~/Content/js/maruti.tables.js",
    "~/Content/js/toaster/toastr.min.js",
    "~/Content/js/sweetalert-dev.js"
               ));


            bundles.Add(new ScriptBundle("~/bundles/bootstrapvalidation").Include(
                 "~/Scripts/jquery-ui.min.js",
     "~/Scripts/jquery.validate.min.js",
     "~/Scripts/jquery.validate.unobtrusive.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                 "~/Content/js/bootstrap-datepicker.js",
    "~/Content/js/fullcalendar.min.js"
                ));
        }
    }
}

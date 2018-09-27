using System.Web;
using System.Web.Optimization;

namespace Clinicas
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/vendors").Include(
                            "~/Scripts/vendors/jquery/js/jquery.js",
                            "~/Scripts/vendors/jquery-validation/jquery.validate.min.js",
                            "~/Scripts/vendors/jquery-validation/additional-methods.min.js",
                            "~/Scripts/vendors/jquery-validation/messages_es.js",
                            "~/Scripts/vendors/popper.js/js/popper.min.js",
                            "~/Scripts/vendors/bootstrap/js/bootstrap.min.js",
                            "~/Scripts/vendors/pace-progress/js/pace.min.js",
                            "~/Scripts/vendors/perfect-scrollbar/js/perfect-scrollbar.min.js",
                            "~/Scripts/vendors/@coreui/coreui/js/coreui.min.js",
                            "~/Scripts/vendors/chart.js/js/Chart.min.js",
                            "~/Scripts/vendors/datatables.net/js/jquery.dataTables.js",
                            "~/Scripts/vendors/datatables.net-bs4/js/dataTables.bootstrap4.js",
                            "~/Scripts/vendors/datatables.net-responsive/js/dataTables.responsive.js",
                            "~/Scripts/vendors/datatables.net-responsive-bs4/js/responsive.bootstrap4.js",
                            "~/Scripts/vendors/moment/min/moment.min.js",
                            "~/Scripts/vendors/datetimepicker.bootstrap4/build/js/bootstrap-datetimepicker.min.js",
                            "~/Scripts/vendors/fullcalendar/dist/fullcalendar.min.js",
                            "~/Scripts/vendors/fullcalendar/dist/locale-all.js",
                            "~/Scripts/vendors/daterangepicker/daterangepicker.js",
                            "~/Scripts/vendors/sweetalert2/dist/sweetalert2.js"
                        ));

            bundles.Add(new StyleBundle("~/bundles/vendors").Include(
                        "~/Scripts/vendors/@coreui/icons/css/coreui-icons.min.css",
                        "~/Scripts/vendors/flag-icon-css/css/flag-icon.min.css",
                        "~/Scripts/vendors/font-awesome/css/font-awesome.min.css",
                        "~/Scripts/vendors/simple-line-icons/css/simple-line-icons.css",
                        "~/Content/vendors/coreui/style.css",
                        "~/Scripts/vendors/pace-progress/css/pace.min.css",
                        "~/Scripts/vendors/datatables.net-bs4/css/dataTables.bootstrap4.css",
                        "~/Scripts/vendors/datatables.net-responsive-bs4/css/responsive.bootstrap4.css",
                        "~/Scripts/vendors/datetimepicker.bootstrap4/build/css/bootstrap-datetimepicker.min.css",
                        "~/Scripts/vendors/fullcalendar/dist/fullcalendar.min.css",
                        "~/Scripts/vendors/daterangepicker/daterangepicker.css",
                        "~/Scripts/vendors/sweetalert2/dist/sweetalert2.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/js/app").IncludeDirectory(
                        "~/Scripts/MyScripts", "*.js", searchSubdirectories: true
                        ));

            BundleTable.EnableOptimizations = true;
        }
    }
}

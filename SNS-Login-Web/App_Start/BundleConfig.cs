using System.Web;
using System.Web.Optimization;

namespace Project_WorkFlow
{
    public class BundleConfig
    {
        // 묶음에 대한 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=301862를 참조하세요.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
            // 프로덕션에 사용할 준비를 하고 https://modernizr.com의 빌드 도구를 사용하여 필요한 테스트만 선택하세요.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));



            bundles.Add(new ScriptBundle("~/Common/plugins/jquery/jquery.min.js").Include(
                      "~/Common/plugins/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/Common/plugins/bootstrap/js/bootstrap.bundle.min.js").Include(
                      "~/Common/plugins/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/Common/plugins/jquery-ui/jquery-ui.js").Include(
                      "~/Common/plugins/jquery-ui/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/Common/plugins/jquery-ui/jquery-ui.min.js").Include(
                      "~/Common/plugins/jquery-ui/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/Common/dist/js/adminlte.min.js").Include(
                      "~/Common/dist/js/adminlte.min.js"));

            bundles.Add(new ScriptBundle("~/Common/plugins/moment/moment.min.js").Include(
                      "~/Common/plugins/moment/moment.min.js"));

            bundles.Add(new ScriptBundle("~/Common/plugins/fullcalendar/main.js").Include(
                      "~/Common/plugins/fullcalendar/main.js"));

            bundles.Add(new ScriptBundle("~/Common/dist/js/demo.js").Include(
                      "~/Common/dist/js/demo.js"));

            bundles.Add(new ScriptBundle("~/Common/js/custom-calender.js").Include(
                      "~/Common/js/custom-calender.js"));




            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


        }
    }
}

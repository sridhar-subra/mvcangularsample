using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Aveeno1.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/thirdpartyscripts").Include(
                 "~/Scripts/angular.min.js",
                 "~/Scripts/angular-route.min.js",
                 "~/Scripts/jquery-2.1.4.min.js",
                 "~/Scripts/bootstrap.min.js",
                 "~/Scripts/bootbox.min.js",
                 "~/Scripts/d3/d3.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/appscripts").Include(
                "~/Scripts/app_js/app.js",
                "~/Scripts/app_js/PatientController.js",
                "~/Scripts/app_js/patient-chart.js"

               ));

            bundles.Add(new StyleBundle("~/bundle/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/aveeno.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
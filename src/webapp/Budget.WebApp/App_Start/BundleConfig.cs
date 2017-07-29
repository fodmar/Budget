using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Budget.WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery-validation").Include(
                    "~/Scripts/lib/jquery-{version}.js",
                    "~/Scripts/lib/jquery.validate.js",
                    "~/Scripts/lib/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/ui").Include(
                    "~/Scripts/lib/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                    "~/Scripts/lib/moment.js",
                    "~/Scripts/lib/moment-with-locales.js",
                    "~/Scripts/lib/fullcalendar.js",
                    "~/Scripts/lib/locale-all.js"));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                    "~/Scripts/app/calendar.js"));

            bundles.Add(new StyleBundle("~/content/calendar").Include(
                    "~/Content/themes/base/*.css",
                    "~/Content/fullcalendar.css",
                    "~/Content/app.css"));
        }
    }
}
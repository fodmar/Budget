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
            bundles.Add(new ScriptBundle("~/bundles/scripts/login").Include(
                    "~/Scripts/lib/jquery-{version}.js",
                    "~/Scripts/lib/jquery.validate.js",
                    "~/Scripts/lib/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts/overview").Include(
                    "~/Scripts/lib/jquery-{version}.js",
                    "~/Scripts/lib/jquery-ui-{version}.js",
                    "~/Scripts/lib/moment.js",
                    "~/Scripts/lib/moment-with-locales.js",
                    "~/Scripts/lib/fullcalendar.js",
                    "~/Scripts/lib/locale-all.js",
                    "~/Scripts/app/calendar.js"));

            bundles.Add(new StyleBundle("~/bundles/content/overview").Include(
                    "~/Content/lib/jquery-ui.css",
                    "~/Content/lib/fullcalendar.css",
                    "~/Content/app/app.css"));
        }
    }
}
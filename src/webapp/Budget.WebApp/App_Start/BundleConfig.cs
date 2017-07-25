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
                    "~/Scripts/lib/jquery-{version}.min.js").Include(
                    "~/Scripts/lib/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                    "~/Scripts/lib/jquery-{version}.min.js").Include(
                    "~/Scripts/lib/moment.min.js").Include(
                    "~/Scripts/lib/moment-with-locales.min.js").Include(
                    "~/Scripts/lib/fullcalendar.min.js").Include(
                    "~/Scripts/lib/fullcalendar/pl.js").Include(
                    "~/Scripts/app/calendar.js"));

            bundles.Add(new StyleBundle("~/content/calendar").Include(
                    "~/Content/fullcalendar.min.css"));
        }
    }
}
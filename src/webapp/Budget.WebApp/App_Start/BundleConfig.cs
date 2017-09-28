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
            bundles.Add(new StyleBundle("~/bundles/content/overview").Include(
                    "~/Content/lib/jquery-ui.css",
                    "~/Content/app/jquery-ui.css",
                    "~/Content/lib/fullcalendar.css"));

            bundles.Add(new StyleBundle("~/bundles/content/jqueryui").Include(
                    "~/Content/lib/jquery-ui.css",
                    "~/Content/app/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/bundles/content/app").Include(
                    "~/Content/material-icons/material-icons.css",
                    "~/Content/app/app.css"));
        }
    }
}
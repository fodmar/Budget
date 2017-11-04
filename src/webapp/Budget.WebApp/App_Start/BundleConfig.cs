using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Budget.WebApp
{
    public class BundleConfig
    {
        private static BundleCollection bundleCollection;

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundleCollection = bundles;

            Script("layout",
                "~/Scripts/lib/jquery-{version}.js",
                "~/Scripts/lib/bootstrap.js");

            Style("layout",
                "~/Content/material-icons/material-icons.css",
                "~/Content/lib/bootstrap.css",
                "~/Content/lib/bootstrap-theme.css",
                "~/Content/app/app.css");

            Style("overview",
                "~/Content/lib/jquery-ui.css",
                "~/Content/app/jquery-ui.css",
                "~/Content/lib/fullcalendar.css");

            Style("jqueryui",
                "~/Content/lib/jquery-ui.css",
                "~/Content/app/jquery-ui.css");
        }

        private static void Script(string name, params string[] paths)
        {
            bundleCollection.Add(new ScriptBundle(string.Format("~/bundles/scripts/{0}", name)).Include(paths));
        }

        private static void Style(string name, params string[] paths)
        {
            bundleCollection.Add(new StyleBundle(string.Format("~/bundles/content/{0}", name)).Include(paths));
        }
    }
}
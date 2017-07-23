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
                    "~/Scripts/jquery-{version}.min.js").Include(
                    "~/Scripts/jquery.validate*"));
        }
    }
}
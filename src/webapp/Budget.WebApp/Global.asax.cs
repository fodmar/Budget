using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Budget.ObjectModel;

namespace Budget.WebApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.IgnoreRoutes(RouteTable.Routes);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FilterConfig.RegisterFilters(GlobalFilters.Filters);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyResolutionConfig.InitializeDependencyResolution();
        }
    }
}

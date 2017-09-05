using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Budget.Log4net;
using Budget.ObjectModel;

namespace Budget.WebApp
{
    public class BudgetWebApp : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.IgnoreRoutes(RouteTable.Routes);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FilterConfig.RegisterFilters(GlobalFilters.Filters);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyResolutionConfig.InitializeDependencyResolution();

            Log4netSetup.Setup(Server.MapPath("~/bin/log4net.config"));
        }
    }
}

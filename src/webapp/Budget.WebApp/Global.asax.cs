using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Budget.Log4net;
using Budget.ObjectModel;
using Budget.WebApp.Utils;

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
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
        }

        protected void Application_Error()
        {
            Exception ex = this.Server.GetLastError();
            DependencyResolver.Current.GetService<IErrorHandler>().HandleApplicationError(this.Context, ex);
            this.Server.ClearError();
        }

        protected void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
#if DEBUG
            try
            {
                DependencyResolver.Current.GetService<ILogger>().Debug("First chance exception", e.Exception);
            }
            catch (Exception)
            {
            }
#endif
        }
    }
}

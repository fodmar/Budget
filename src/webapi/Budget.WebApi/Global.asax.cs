using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Budget.Log4net;
using Budget.WebApi.DependencyResolution;
using StructureMap;

namespace Budget.WebApi
{
    public class BudgetWebApi : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(ConfigureHttp);
            Log4netSetup.Setup(Server.MapPath("~/bin/log4net.config"));
        }

        private void ConfigureHttp(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            RouteConfig.RegisterRoutes(config.Routes);
            DependencyResolutionConfig.InitializeDependencyResolution(config);
            SwaggerConfig.Register(config);
        }
    }
}

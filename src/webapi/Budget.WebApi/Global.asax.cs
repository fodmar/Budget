using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Budget.WebApi.DependencyResolution;
using StructureMap;

namespace Budget.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(ConfigureHttp);
        }

        private void ConfigureHttp(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            RouteConfig.RegisterRoutes(config.Routes);
            DependencyResolutionConfig.InitializeDependencyResolution(config);
        }
    }
}

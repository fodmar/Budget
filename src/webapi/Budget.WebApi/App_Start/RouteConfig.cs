using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Budget.WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            HttpRouteCollection routes = config.Routes;

            //routes.MapHttpRoute(
            //    name: "User",
            //    routeTemplate: "api/user/{login}/{hash}",
            //    defaults: new { controller = "User", action = "Find" }
            //);
        }
    }
}
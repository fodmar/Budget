using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Budget.WebApi.DependencyResolution;
using Newtonsoft.Json;
using StructureMap;

namespace Budget.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            IContainer container = IoC.Initialize();
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

            WebApiConfig.RegisterRoutes(config.Routes);
        }

        public static void RegisterRoutes(HttpRouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapHttpRoute(
                name: "ReceiptsByDateRange",
                routeTemplate: "api/{controller}/{from}/{to}",
                defaults: new { from = RouteParameter.Optional, to = RouteParameter.Optional }
            );
        }
    }
}

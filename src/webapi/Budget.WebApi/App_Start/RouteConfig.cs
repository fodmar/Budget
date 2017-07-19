using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Budget.WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(HttpRouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "ListAll",
                routeTemplate: "api/{controller}/"
            );

            routes.MapHttpRoute(
                name: "GetOne",
                routeTemplate: "api/{controller}/{id}"
            );

            routes.MapHttpRoute(
                name: "ReceiptsByDateRange",
                routeTemplate: "api/{controller}/{from}/{to}"
            );
        }
    }
}
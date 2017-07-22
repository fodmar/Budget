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
                name: "User",
                routeTemplate: "api/user/{login}/{hash}",
                defaults: new { controller = "User", action = "Find" }
            );

            routes.MapHttpRoute(
                name: "ReceiptsByDateRange",
                routeTemplate: "api/receipt/{userId}/{from}/{to}",
                defaults: new { controller = "Receipt", action = "GetReceiptsFromDateRange" }
            );

            routes.MapHttpRoute(
                name: "GetOne",
                routeTemplate: "api/receipt/{userId}/{receiptId}",
                defaults: new { controller = "Receipt", action = "GetReceipt" }
            );

            routes.MapHttpRoute(
                name: "ListAll",
                routeTemplate: "api/receipt/{userId}",
                defaults: new { controller = "Receipt", action = "GetReceipts" }
            );
        }
    }
}
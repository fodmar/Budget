﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Budget.WebApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.IgnoreRoutes(RouteTable.Routes);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

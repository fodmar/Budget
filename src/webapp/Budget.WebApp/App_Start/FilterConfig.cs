using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.WebApp.Filters;

namespace Budget.WebApp.App_Start
{
    public class FilterConfig
    {
        public static void RegisterFilters(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new CorrelationIdAttribute());
        }
    }
}
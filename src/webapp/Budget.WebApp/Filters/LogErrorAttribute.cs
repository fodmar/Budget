using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;

namespace Budget.WebApp.Filters
{
    public class LogErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            ILogger logger = DependencyResolver.Current.GetService<ILogger>();

            string userName = "[unauthenticated]";
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                userName = filterContext.HttpContext.User.Identity.Name;
            }

            string msg = string.Format("{0} {1}", userName, filterContext.HttpContext.Request.RawUrl);

            logger.Error(msg, filterContext.Exception);

            base.OnException(filterContext);
        }
    }
}
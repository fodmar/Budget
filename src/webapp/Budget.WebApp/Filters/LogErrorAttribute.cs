using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;
using Budget.Resources;
using Budget.WebApp.Models;

namespace Budget.WebApp.Filters
{
    public class LogErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            HttpContextBase httpContext = filterContext.HttpContext;

            string userName = "[unauthenticated]";
            if (httpContext.User.Identity.IsAuthenticated)
            {
                userName = httpContext.User.Identity.Name;
            }

            string msg = string.Format("{0} {1}", userName, filterContext.HttpContext.Request.RawUrl);

            ILogger logger = DependencyResolver.Current.GetService<ILogger>();
            logger.Error(msg, filterContext.Exception);

            if (httpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = new ErrorModel(Text.UnexpectedError)
                };
            }
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = MVC.Error.Views.Error
                };
            }

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            filterContext.ExceptionHandled = true;
        }
    }
}
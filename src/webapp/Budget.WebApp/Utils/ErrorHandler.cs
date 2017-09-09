using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Budget.ObjectModel;
using Budget.Resources;
using Budget.WebApp.Models;

namespace Budget.WebApp.Utils
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly ILogger logger;

        public ErrorHandler(ILogger logger)
        {
            this.logger = logger;
        }

        public void HandleControllerError(ExceptionContext exceptionContext)
        {
            if (exceptionContext.ExceptionHandled)
            {
                return;
            }

            HttpContextBase httpContext = exceptionContext.HttpContext;

            string message = this.CreateMessage(httpContext.ApplicationInstance.Context);
            this.logger.Error(message, exceptionContext.Exception);

            if (httpContext.Request.IsAjaxRequest())
            {
                exceptionContext.Result = new JsonResult
                {
                    Data = new ErrorModel(Text.UnexpectedError)
                };
            }
            else
            {
                exceptionContext.Result = new ViewResult
                {
                    ViewName = MVC.Error.Views.Error
                };
            }

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            exceptionContext.ExceptionHandled = true;
        }

        public void HandleApplicationError(HttpContext httpContext, Exception ex)
        {
            this.logger.Error(this.CreateMessage(httpContext), ex);

            if (httpContext.CurrentHandler is MvcHandler == false)
            {
                return;
            }

            RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
            requestContext.RouteData.Values["action"] = MVC.Error.ActionNames.Error;
            requestContext.RouteData.Values["controller"] = MVC.Error.Name;

            IControllerFactory controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            IController controller = controllerFactory.CreateController(requestContext, MVC.Error.Name);

            controller.Execute(requestContext);
        }

        private string CreateMessage(HttpContext httpContext)
        {
            string userName = "[unauthenticated]";
            if (httpContext.User.Identity.IsAuthenticated)
            {
                userName = httpContext.User.Identity.Name;
            }

            return string.Format("{0} {1}", userName, httpContext.Request.RawUrl);
        }
    }
}
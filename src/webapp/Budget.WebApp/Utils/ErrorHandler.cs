using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Budget.ObjectModel;
using Budget.Resources;
using Budget.WebApp.Controllers;
using Budget.WebApp.Models;

namespace Budget.WebApp.Utils
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly ILogger logger;
        private readonly Dictionary<int, string> actionsForStatusCodes;

        public ErrorHandler(ILogger logger)
        {
            this.logger = logger;
            this.actionsForStatusCodes = new Dictionary<int, string>();

            ErrorController.ActionNamesClass actionNames = MVC.Error.ActionNames;
            this.actionsForStatusCodes[(int)HttpStatusCode.BadRequest] = actionNames.BadRequest;
            this.actionsForStatusCodes[(int)HttpStatusCode.Forbidden] = actionNames.Forbidden;
            this.actionsForStatusCodes[(int)HttpStatusCode.NotFound] = actionNames.NotFound;
            this.actionsForStatusCodes[(int)HttpStatusCode.InternalServerError] = actionNames.Error;
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

            HttpException httpException = ex as HttpException;

            if (httpException == null)
            {
                return;
            }

            if (httpContext.CurrentHandler is MvcHandler == false)
            {
                return;
            }

            string actionName = null;
            this.actionsForStatusCodes.TryGetValue(httpException.GetHttpCode(), out actionName);

            RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
            requestContext.RouteData.Values["action"] = actionName ?? MVC.Error.ActionNames.Error;
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
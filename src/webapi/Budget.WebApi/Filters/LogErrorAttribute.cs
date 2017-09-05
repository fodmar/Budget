using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using Budget.ObjectModel;

namespace Budget.WebApi.Filters
{
    public class LogErrorAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ILogger logger = context.ActionContext.RequestContext.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;

            string msg = string.Format("{0}", context.Request.RequestUri.OriginalString);

            logger.Error(msg, context.Exception);

            base.OnException(context);
        }
    }
}
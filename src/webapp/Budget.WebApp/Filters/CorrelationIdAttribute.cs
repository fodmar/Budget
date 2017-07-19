using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.WebApp.Filters
{
    public class CorrelationIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequest currentRequest = HttpContext.Current.Request;

            if (currentRequest.Headers.AllKeys.Contains("correlationId"))
            {
                string correlationId = currentRequest.Headers.GetValues("correlationId").First();

                Guid result;

                if (Guid.TryParse(correlationId, out result))
                {
                    Trace.CorrelationManager.ActivityId = result;
                }
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.AddHeader("correlationId", Trace.CorrelationManager.ActivityId.ToString());
        }
    }
}
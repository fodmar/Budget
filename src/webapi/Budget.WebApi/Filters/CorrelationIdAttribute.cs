using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Budget.WebApi.Filters
{
    public class CorrelationIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            HttpRequestMessage currentRequest = actionContext.Request;

            if (currentRequest.Headers.Contains("correlationId"))
            {
                string correlationId = currentRequest.Headers.GetValues("correlationId").First();

                Guid result;

                if (Guid.TryParse(correlationId, out result))
                {
                    Trace.CorrelationManager.ActivityId = result;
                }
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response == null)
            {
                return;
            }

            actionExecutedContext.Response.Headers.Add("correlationId", Trace.CorrelationManager.ActivityId.ToString());
        }
    }
}
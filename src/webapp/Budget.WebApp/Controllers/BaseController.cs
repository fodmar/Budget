using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.WebApp.Filters;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Controllers
{
    [Authorize]
    [CorrelationId]
    [LogErrorAttribute]
    public abstract partial class BaseController : Controller
    {
        protected ISessionHelper sessionHelper;

        [Obsolete("This constructor is required by T4MVC lib, don't use it")]
        protected BaseController()
        {
        }

        public BaseController(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }

        protected override void OnException(ExceptionContext exceptionContext)
        {
            DependencyResolver.Current.GetService<IErrorHandler>().HandleControllerError(exceptionContext);
        }
    }
}
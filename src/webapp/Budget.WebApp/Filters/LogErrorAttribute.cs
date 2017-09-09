using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;
using Budget.Resources;
using Budget.WebApp.Models;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Filters
{
    public class LogErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            DependencyResolver.Current.GetService<IErrorHandler>().HandleControllerError(exceptionContext);
        }
    }
}
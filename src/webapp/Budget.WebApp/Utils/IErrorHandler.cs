using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Budget.WebApp.Utils
{
    public interface IErrorHandler
    {
        void HandleControllerError(ExceptionContext exceptionContext);

        void HandleApplicationError(HttpContext httpContext, Exception ex);
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Filters
{
    public class LanguageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = DependencyResolver.Current.GetService<ICookieHelper>().Language;

            if (string.IsNullOrEmpty(lang))
            {
                return;
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
        }
    }
}
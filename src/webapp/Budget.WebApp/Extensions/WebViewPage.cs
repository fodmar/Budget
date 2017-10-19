using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Extensions
{
    public abstract class WebViewPage<T> : System.Web.Mvc.WebViewPage<T>
    {
        public ISessionHelper SessionHelper
        {
            get
            {
                return DependencyResolver.Current.GetService<ISessionHelper>();
            }
        }
    }
}
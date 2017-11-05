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
        private Bootstrap<T> bootstrap;

        public Bootstrap<T> Bootstrap
        {
            get
            {
                if (bootstrap == null)
                {
                    bootstrap = new Bootstrap<T>(this.Html, this.Url, this.SessionHelper);
                }

                return bootstrap;
            }
        }

        public ISessionHelper SessionHelper
        {
            get
            {
                return DependencyResolver.Current.GetService<ISessionHelper>();
            }
        }
    }
}
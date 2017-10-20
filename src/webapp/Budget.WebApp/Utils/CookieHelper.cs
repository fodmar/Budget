using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget.WebApp.Utils
{
    public class CookieHelper : ICookieHelper
    {
        public string Language
        {
            get
            {
                return this.Get(CookieKeys.Language);
            }
            set
            {
                this.Set(CookieKeys.Language, value);
            }
        }

        private string Get(CookieKeys key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key.ToString()];

            return cookie == null ? null : cookie.Value;
        }

        private void Set(CookieKeys key, string value)
        {
            HttpCookie cookie = new HttpCookie(key.ToString());
            cookie.Expires = DateTime.Now.AddMonths(1);
            cookie.Value = value;

            HttpContext.Current.Response.SetCookie(cookie);
        }
    }
}
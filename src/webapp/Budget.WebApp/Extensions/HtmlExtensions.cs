using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.WebApp.Extensions
{
    public static class HtmlExtensions
    {
        public static IHtmlString SubmitForm(this HtmlHelper helper, string text)
        {
            return new MvcHtmlString(string.Format("<div><input type='submit' value={0} /></div>", text));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Controllers
{
    public partial class LanguageController : BaseController
    {
        private readonly ICookieHelper cookieHelper;

        public LanguageController(ICookieHelper cookieHelper)
        {
            this.cookieHelper = cookieHelper;
        }

        [AllowAnonymous]
        public virtual ActionResult Change(string id)
        {
            this.cookieHelper.Language = id;

            string redirectTo = Url.Content(@"~/");

            if (this.Request.UrlReferrer != null)
            {
                redirectTo = this.Request.UrlReferrer.AbsoluteUri;
            }

            return Redirect(redirectTo);
        }
    }
}
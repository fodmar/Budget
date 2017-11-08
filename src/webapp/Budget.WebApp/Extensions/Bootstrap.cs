using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Budget.WebApp.Utils;

namespace Budget.WebApp.Extensions
{
    public class Bootstrap<T>
    {
        private readonly HtmlHelper<T> htmlHelper;
        private readonly UrlHelper urlHelper;
        private readonly ISessionHelper sessionHelper;

        public Bootstrap(HtmlHelper<T> htmlHelper, UrlHelper urlHelper, ISessionHelper sessionHelper)
        {
            this.htmlHelper = htmlHelper;
            this.urlHelper = urlHelper;
            this.sessionHelper = sessionHelper;
        }

        public IHtmlString FormForModel(string submitText, string action = null, string controller = null)
        {
            ViewDataDictionary viewData = new ViewDataDictionary(this.htmlHelper.ViewData);
            viewData.Add("action", action);
            viewData.Add("controller", controller);
            viewData.Add("submitText", submitText);
            return this.htmlHelper.Partial(MVC.Shared.Views.Bootstrap.Form, viewData);
        }

        public IHtmlString SubmitForm(string text)
        {
            return new MvcHtmlString(string.Format("<button class='btn btn-block btn-primary center-all' type='submit'>{0}</button>", text));
        }

        public IHtmlString ValidationSummary(bool includePropertyErros = false)
        {
            var model = new ValidationSummaryModel(this.htmlHelper.ViewData.ModelState, includePropertyErros);
            return this.htmlHelper.Partial(MVC.Shared.Views.Bootstrap.ValidationSummary, model);
        }

        public IHtmlString Navbar()
        {
            NavbarModel model = new NavbarModel(this.htmlHelper.ViewContext.RouteData.Values, this.urlHelper);
            model.UserName = this.sessionHelper.User.Name;

            return this.htmlHelper.Partial(MVC.Shared.Views.Bootstrap.Navbar, model);
        }
    }
}
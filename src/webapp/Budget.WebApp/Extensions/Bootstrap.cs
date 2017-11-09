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

        public IHtmlString FormForModel(FormOptions formOptions)
        {
            ViewDataDictionary viewData = new ViewDataDictionary(this.htmlHelper.ViewData);
            viewData.Add("formOptions", formOptions);

            return this.htmlHelper.Partial(MVC.Shared.Views.Bootstrap.Form, viewData);
        }

        public IHtmlString FormInlineForModel(FormOptions formOptions)
        {
            this.AddAttribute(formOptions.HtmlAttributes, "class", "form-inline");
            formOptions.FullWidthSubmit = false;
            return this.FormForModel(formOptions);
        }

        public IHtmlString FormFor<TModel>(FormOptions formOptions) where TModel : new()
        {
            var viewData = new ViewDataContainer<TModel>(new TModel());
            viewData.Add("formOptions", formOptions);

            HtmlHelper<TModel> helper = new HtmlHelper<TModel>(this.htmlHelper.ViewContext, viewData);
            return helper.Partial(MVC.Shared.Views.Bootstrap.Form, viewData);
        }

        public IHtmlString FormInlineFor<TModel>(FormOptions formOptions) where TModel : new()
        {
            this.AddAttribute(formOptions.HtmlAttributes, "class", "form-inline");
            formOptions.FullWidthSubmit = false;
            return this.FormFor<TModel>(formOptions);
        }

        public IHtmlString SubmitForm(string text, bool fullWidth = true)
        {
            string classes = "btn btn-primary ";

            if (fullWidth)
            {
                classes += "btn-block";
            }

            return new MvcHtmlString(string.Format("<button class='{1}' type='submit'>{0}</button>", text, classes));
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

        private Dictionary<string, object> AddAttribute(Dictionary<string, object> attributes, string key, string value)
        {
            attributes = attributes ?? new Dictionary<string, object>();
            if (attributes.ContainsKey(key))
            {
                string classes = attributes[key] as string;
                classes += " " + value;
                attributes[key] = classes;
            }
            else
            {
                attributes.Add(key, value);
            }

            return attributes;
        }
    }
}
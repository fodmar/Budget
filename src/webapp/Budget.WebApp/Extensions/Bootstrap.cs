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
        private readonly HtmlHelper htmlHelper;
        private readonly ISessionHelper sessionHelper;

        public Bootstrap(HtmlHelper htmlHelper, ISessionHelper sessionHelper)
        {
            this.htmlHelper = htmlHelper;
            this.sessionHelper = sessionHelper;
        }

        public IHtmlString EditorForModel()
        {
            return this.htmlHelper.EditorForModel(MVC.Shared.Views.EditorTemplates.BootstrapEditorForModel);
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
            NavbarModel model = new NavbarModel();
            model.UserName = this.sessionHelper.User.Name;

            return this.htmlHelper.Partial(MVC.Shared.Views.Bootstrap.Navbar, model);
        }
    }
}
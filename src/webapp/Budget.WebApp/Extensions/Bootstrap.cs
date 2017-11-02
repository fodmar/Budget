using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Budget.WebApp.Extensions
{
    public class Bootstrap<T>
    {
        private readonly HtmlHelper htmlHelper;

        public Bootstrap(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        public IHtmlString EditorForModel()
        {
            return this.htmlHelper.EditorForModel(MVC.Shared.Views.EditorTemplates.BootstrapEditorForModel);
        }

        public IHtmlString SubmitForm(string text)
        {
            return new MvcHtmlString(string.Format("<button class='btn btn-block btn-primary center-all' type='submit'>{0}</button>", text));
        }

        public IHtmlString ValidationSummary()
        {
            return this.htmlHelper.Partial(MVC.Shared.Views.BootstrapValidationSummary, this.htmlHelper.ViewData.ModelState);
        }
    }
}
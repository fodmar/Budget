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

        public MvcHtmlString EditorForModel()
        {
            return this.htmlHelper.EditorForModel(MVC.Shared.Views.EditorTemplates.BootstrapEditorForModel);
        }
    }
}
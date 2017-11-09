using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget.WebApp.Extensions
{
    public class FormOptions
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string SubmitText { get; set; }
        public bool FullWidthSubmit { get; set; }
        public Dictionary<string, object> HtmlAttributes { get; set; }

        public static FormOptions Options(string submitText, string action, string controller)
        {
            return new FormOptions
            {
                Action = action,
                Controller = controller,
                SubmitText = submitText,
                FullWidthSubmit = true,
                HtmlAttributes = new Dictionary<string,object>()
            };
        }
    }
}
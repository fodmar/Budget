using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.WebApp.Extensions
{
    public class FormOptions
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string SubmitText { get; set; }
        public bool FullWidthSubmit { get; set; }
        public Dictionary<string, object> FormAttributes { get; set; }
        public Dictionary<string, object> LabelAttributes { get; set; }

        public string LabelSize { get; set; }
        public string InputWidth { get; set; }

        public static FormOptions Options(string submitText, string action, string controller)
        {
            return new FormOptions
            {
                Action = action,
                Controller = controller,
                SubmitText = submitText,
                FullWidthSubmit = true,
                FormAttributes = new Dictionary<string,object>(),
                LabelAttributes = new Dictionary<string, object>()
            };
        }
    }
}
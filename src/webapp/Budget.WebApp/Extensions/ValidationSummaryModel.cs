using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.WebApp.Extensions
{
    public class ValidationSummaryModel
    {
        public ValidationSummaryModel(ModelStateDictionary modelState, bool includePropertyErros)
        {
            this.IncludePropertyErros = includePropertyErros;

            if (includePropertyErros)
            {
                this.PropertyErrors = modelState.AsEnumerable();
            }
            else
            {
                this.PropertyErrors = modelState.Where(p => string.IsNullOrEmpty(p.Key));
            }
        }

        public IEnumerable<KeyValuePair<string, ModelState>> PropertyErrors { get; private set; }
        public bool IncludePropertyErros { get; private set; }
        public bool IsValid
        {
            get
            {
                return !this.PropertyErrors.Any();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.WebApp.Extensions
{
    public class ViewDataContainer<TModel> : ViewDataDictionary<TModel>, IViewDataContainer
    {
        public ViewDataContainer(TModel model) : base(model)
        {
            ViewData = new ViewDataDictionary(model);
        }

        public ViewDataDictionary ViewData { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace Budget.WebApi.ModelBinders
{
    public class DateTimeFromUnixTimeStampBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(DateTime)
                && bindingContext.ModelType != typeof(DateTime?))
            {
                return false;
            }

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == null)
            {
                return false;
            }

            var stringValue = value.RawValue.ToString();

            if (string.IsNullOrEmpty(stringValue))
            {
                return false;
            }

            if (stringValue == "null")
            {
                if (bindingContext.ModelType == typeof(DateTime?))
                {
                    bindingContext.Model = (DateTime?)null;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            long unixTimeStamp;

            if (long.TryParse(stringValue, out unixTimeStamp))
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                bindingContext.Model = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
                return true;
            }

            return false;
        }
    }
}
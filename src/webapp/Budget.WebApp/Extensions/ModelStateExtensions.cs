using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.WebApp.Extensions
{
    public static class ModelStateExtensions
    {
        public static Dictionary<string, string[]> PropertiesErrors(this ModelStateDictionary modelStateDictionary)
        {
            var result = new Dictionary<string, string[]>();

            foreach (KeyValuePair<string, ModelState> item in modelStateDictionary)
            {
                List<string> propertyErrors = new List<string>();

                foreach (ModelError error in item.Value.Errors)
                {
                    if (!string.IsNullOrEmpty(error.ErrorMessage))
                    {
                        propertyErrors.Add(error.ErrorMessage);
                    }

                    if (error.Exception != null)
                    {
                        propertyErrors.Add(error.Exception.Message);
                    }
                }

                if (propertyErrors.Count == 0)
                {
                    continue;
                }

                string property = item.Key;
                if (result.ContainsKey(property))
                {
                    result[property] = result[property].Union(propertyErrors).ToArray();  
                }
                else
                {
                    result.Add(property, propertyErrors.ToArray());
                }
            }

            return result;
        }
    }
}
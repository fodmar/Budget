using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Budget.Resources;

namespace Budget.WebApp.Attributes
{
    public class NotEmptyAttribute : ValidationAttribute
    {
        public NotEmptyAttribute()
        {
            this.ErrorMessageResourceType = typeof(Text);
            this.ErrorMessageResourceName = "CollectionShouldHaveAtLeastOneElement";
        }

        public override bool IsValid(object value)
        {
            var enumerable = value as IEnumerable;

            if (enumerable == null)
            {
                // RequiredAttribute should handle this
                return true;
            }

            return enumerable.GetEnumerator().MoveNext();
        }
    }
}
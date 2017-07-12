using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.WebApi.Client
{
    internal static class DateTimeExtensions
    {
        private static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static string ToUriParamString(this DateTime dateTime)
        {
            return (dateTime.ToUniversalTime() - UnixEpoch).TotalSeconds.ToString();
        }

        public static string ToUriParamString(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToUriParamString();
            }

            return "null";
        }
    }
}

using System;

namespace Budget.Utils.Extensions
{
    public static class DateTimeExtensions
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

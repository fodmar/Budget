namespace Budget.WebApp.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToLowerString(this bool value)
        {
            return value ? "true" : "false";
        }
    }
}
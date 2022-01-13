namespace AspApiSample.Web.Extensions
{
    public static class StringExtensionMethods
    {
        public static string Remove(this string str, char charToRemove)
        {
            return str.Replace(charToRemove.ToString(), string.Empty);
        }
    }
}
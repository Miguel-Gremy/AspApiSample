using System.Collections.Generic;
using IO.Swagger.Client;

namespace AspApiSample.Web.Extensions
{
    public static class ApiExceptionExtension
    {
        private static string GetDetailString(this ApiException e)
        {
            return new string(e.ErrorContent).RemoveChar('\"');
        }

        public static IEnumerable<string> GetDetailTable(this ApiException e)
        {
            return e.GetDetailString().Split(@"\r\n");
        }
    }
}
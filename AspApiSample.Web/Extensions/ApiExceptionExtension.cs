using IO.Swagger.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return e.GetDetailString().Split("\r\n");
        }
    }
}

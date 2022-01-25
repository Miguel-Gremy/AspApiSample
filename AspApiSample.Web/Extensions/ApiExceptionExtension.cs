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
        public static string GetDetailString(this ApiException e)
        {
            return new string(JObject.Parse(e.ErrorContent.ToString()).detail.ToString()).RemoveChar('\"');
        }

        public static string[] GetDetailTable(this ApiException e)
        {
            return new string(JObject.Parse(e.ErrorContent.ToString()).detail.ToString()).RemoveChar('\"').Split("\r\n");
        }
    }
}

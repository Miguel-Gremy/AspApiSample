using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspApiSample.Web.Extensions
{
    public static class ModelStateExtension
    {
        public static IEnumerable<string> GetErrorsAsStringTable(
            this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
        }
    }
}
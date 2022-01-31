using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace AspApiSample.API.Extensions
{
    public static class IdentityErrorsExtension
    {
        public static string GetErrorsAsString(this IEnumerable<IdentityError> errors)
        {
            return errors.Aggregate(string.Empty,
                (current, error) => current + $"{error.Code} : {error.Description} \r\n ");
        }
    }
}

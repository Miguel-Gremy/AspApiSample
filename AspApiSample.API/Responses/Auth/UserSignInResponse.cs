using System.Collections.Generic;
using AspApiSample.Lib.Models;

namespace AspApiSample.API.Responses.Auth
{
    public class UserSignInResponse
    {
        public User User { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
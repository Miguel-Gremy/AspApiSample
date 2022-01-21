using System.Collections.Generic;

namespace AspApiSample.API.Responses.Auth
{
    public class UserSignInResponse
    {
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
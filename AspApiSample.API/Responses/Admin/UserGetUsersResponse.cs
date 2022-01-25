using System.Collections.Generic;
using AspApiSample.Lib.Models;

namespace AspApiSample.API.Responses.Admin
{
    public class UserGetUsersResponse
    {
        public IEnumerable<User> Users { get; set; }
    }
}
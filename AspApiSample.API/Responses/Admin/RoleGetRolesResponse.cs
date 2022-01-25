using System.Collections.Generic;
using AspApiSample.Lib.Models;

namespace AspApiSample.API.Responses.Admin
{
    public class RoleGetRolesResponse
    {
        public IEnumerable<Role> Roles { get; set; }
    }
}
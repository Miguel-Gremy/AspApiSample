using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AspApiSample.API.Responses.Admin
{
    public class RoleGetRolesResponse
    {
        public IEnumerable<IdentityRole<long>> Roles { get; set; }
    }
}
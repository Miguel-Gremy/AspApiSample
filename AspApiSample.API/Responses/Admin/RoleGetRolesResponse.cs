using System.Collections;
using System.Collections.Generic;
using AspApiSample.Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace AspApiSample.API.Responses.Admin
{
    public class RoleGetRolesResponse
    {
        public IEnumerable<Role> Roles { get; set; }
    }
}
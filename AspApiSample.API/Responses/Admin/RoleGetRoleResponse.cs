using Microsoft.AspNetCore.Identity;

namespace AspApiSample.API.Responses.Admin
{
    public class RoleGetRoleResponse
    {
        public IdentityRole<long> Role { get; set; }
    }
}
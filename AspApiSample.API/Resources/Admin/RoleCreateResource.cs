using System.ComponentModel.DataAnnotations;

namespace AspApiSample.API.Resources.Admin
{
    public class RoleCreateResource
    {
        [Required] public string RoleName { get; set; }
    }
}
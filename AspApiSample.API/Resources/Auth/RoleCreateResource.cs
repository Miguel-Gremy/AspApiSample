using System.ComponentModel.DataAnnotations;

namespace AspApiSample.API.Resources.Auth
{
    public class RoleCreateResource
    {
        [Required] public string RoleName { get; set; }
    }
}
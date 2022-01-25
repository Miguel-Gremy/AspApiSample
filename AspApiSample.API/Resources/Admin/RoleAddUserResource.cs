using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.API.Resources.Admin
{
    public class
        RoleAddUserResource
    {
        [FromBody] [Required] public string RoleName { get; set; }
    }
}
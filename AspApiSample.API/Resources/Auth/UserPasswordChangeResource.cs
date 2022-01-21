using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.API.Resources.Auth
{
    public class UserPasswordChangeResource
    {
        [Required] [FromBody] [EmailAddress] public string Email { get; set; }

        [Required]
        [FromBody]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [FromBody]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
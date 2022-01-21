using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.API.Resources.Auth
{
    public class UserPasswordResetResource
    {
        [Required] [EmailAddress] [FromBody] public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [FromBody]
        public string Password { get; set; }

        [Required] [FromBody] public string Token { get; set; }
    }
}
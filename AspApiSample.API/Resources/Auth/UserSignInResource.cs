using System.ComponentModel.DataAnnotations;

namespace AspApiSample.API.Resources.Auth
{
    public class UserSignInResource
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
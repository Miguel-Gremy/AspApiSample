using System.ComponentModel.DataAnnotations;

namespace AspApiSample.API.Resources.Auth
{
    public class UserSignUpResource
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
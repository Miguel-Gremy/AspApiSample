using System.ComponentModel.DataAnnotations;

namespace AspApiSample.API.Resources.Auth
{
    public class UserSignUpConfirmResource
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

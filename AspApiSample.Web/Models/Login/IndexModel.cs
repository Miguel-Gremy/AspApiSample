using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Login
{
    public class IndexModel : ModelBase
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email address", Prompt = "example@address.com")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
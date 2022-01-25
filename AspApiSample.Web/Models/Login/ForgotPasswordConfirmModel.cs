using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Login
{
    public class ForgotPasswordConfirmModel : ModelBase
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email address", Prompt = "Email address")]
        public string Email { get; set; }
    }
}
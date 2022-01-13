using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Account
{
    public class ForgotPasswordModel : ModelBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Account
{
    public class ForgotPasswordConfirmModel : ModelBase
    {
        [Required]
        public string Email { get; set; }
    }
}
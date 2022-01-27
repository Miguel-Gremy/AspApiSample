using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Login
{
    public class ForgotPasswordModel : ModelBase
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email address", Prompt = "example@address.com")]
        public string Email { get; set; }


        public override void ResetData()
        {
            
        }
    }
}
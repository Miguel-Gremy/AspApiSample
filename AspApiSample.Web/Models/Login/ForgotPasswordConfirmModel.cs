using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Login
{
    public class ForgotPasswordConfirmModel : ModelBase
    {
        [Required] public string Email { get; set; }
    }
}
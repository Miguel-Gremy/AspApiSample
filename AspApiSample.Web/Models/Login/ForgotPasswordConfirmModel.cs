using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Login
{
    public class ForgotPasswordConfirmModel : ModelBase
    {
        public string Email { get; set; }
    }
}
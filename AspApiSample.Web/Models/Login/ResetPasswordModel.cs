using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Login
{
    public class ResetPasswordModel : ModelBase
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Password", Prompt = "Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [HiddenInput]
        public string Email { get; set; }
        [Required]
        [HiddenInput]
        public string Token { get; set; }
    }
}
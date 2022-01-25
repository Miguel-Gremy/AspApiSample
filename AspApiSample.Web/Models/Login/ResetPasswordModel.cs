using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.Web.Models.Login
{
    public class ResetPasswordModel : ModelBase
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords does not match")]
        public string ConfirmPassword { get; set; }

        [Required] [HiddenInput] public string Email { get; set; }

        [Required] [HiddenInput] public string Token { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.Web.Models.Account
{
    public class ChangePasswordModel : ModelBase
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password", Prompt = "Current password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password", Prompt = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password", Prompt = "Confirm new password")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords does not match")]
        public string ConfirmNewPassword { get; set; }

        [Required] [HiddenInput] public string EmailAddress { get; set; }
    }
}
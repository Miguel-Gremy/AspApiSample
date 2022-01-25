using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        [Compare(nameof(NewPassword),
            ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm new password", Prompt = "Confirm new password")]
        public string ConfirmNewPassword { get; set; }

        [Required]
        [HiddenInput]
        public string EmailAddress { get; set; }
    }
}
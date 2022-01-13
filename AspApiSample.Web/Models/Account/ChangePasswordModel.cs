using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Account
{
    public class ChangePasswordModel : ModelBase
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
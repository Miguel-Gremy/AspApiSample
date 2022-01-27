using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspApiSample.Web.Models.Admin
{
    public class AddUserModel : ModelBase
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email address", Prompt = "Email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name", Prompt = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name", Prompt = "Last name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords does not match")]
        public string ConfirmPassword { get; set; }
    }
}

using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspApiSample.Web.Models.Admin
{
    public class AddUserModel : ModelBase
    {
        public AddUserModel()
        {

        }

        public AddUserModel(IEnumerable<Role> roles)
        {
            Roles = roles;
        }

        public IEnumerable<Role> Roles { get; set; }

        [Required]
        [MinLength(1)]
        [Display(Name = "Role(s)", Prompt = "Role(s)")]
        public List<string> SelectedRoles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email address", Prompt = "Email address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "First name", Prompt = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last name", Prompt = "Last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords does not match")]
        public string ConfirmPassword { get; set; } = string.Empty;


        public override void ResetData()
        {
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}

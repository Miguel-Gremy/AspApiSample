using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AspApiSample.Lib.Models
{
    public class User : IdentityUser<long>
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Please provide FirstName", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Please provide LastName", AllowEmptyStrings = false)]
        public string LastName { get; set; }
    }
}
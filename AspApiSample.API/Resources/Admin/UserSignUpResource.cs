using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspApiSample.API.Resources.Admin
{
    public class UserCreateResource
    {
        [Required] public string Email { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string Password { get; set; }

        [Required] public IEnumerable<string> Roles { get; set; }
    }
}
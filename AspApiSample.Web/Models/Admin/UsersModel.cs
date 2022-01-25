using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Model;

namespace AspApiSample.Web.Models.Admin
{
    public class UsersModel : ModelBase
    {
        [Required]
        [Display(Name = "Users", Prompt = "Users")]
        public IEnumerable<User> Users { get; set; }
    }
}
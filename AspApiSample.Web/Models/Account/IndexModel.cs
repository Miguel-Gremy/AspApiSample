using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Model;

namespace AspApiSample.Web.Models.Account
{
    public class IndexModel : ModelBase
    {
        [Required]
        [Display(Name = "Users", Prompt = "Users")]
        public User User { get; set; }
    }
}
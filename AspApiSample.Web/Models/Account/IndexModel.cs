using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Model;

namespace AspApiSample.Web.Models.Account
{
    public class IndexModel : ModelBase
    {
        [Required]
        public User User { get; set; }

        public ICollection<string> Messages { get; set; }
    }
}
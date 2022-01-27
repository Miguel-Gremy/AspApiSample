using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Model;

namespace AspApiSample.Web.Models.Admin
{
    public class RolesModel : ModelBase
    {
        [Required]
        [Display(Name = "Roles", Prompt = "Roles")]
        public IEnumerable<Role> Roles { get; set; }


        public override void ResetData()
        {
            
        }
    }
}
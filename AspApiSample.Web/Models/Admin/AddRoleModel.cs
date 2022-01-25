using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspApiSample.Web.Models.Admin
{
    public class AddRoleModel : ModelBase
    {
        [Required]
        [Display(Name = "Role name", Prompt = "Role name")]
        public string RoleName { get; set; }
    }
}

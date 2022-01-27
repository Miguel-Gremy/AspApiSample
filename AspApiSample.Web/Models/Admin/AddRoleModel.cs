using System.ComponentModel.DataAnnotations;

namespace AspApiSample.Web.Models.Admin
{
    public class AddRoleModel : ModelBase
    {
        [Required]
        [Display(Name = "Role name", Prompt = "Role name")]
        public string RoleName { get; set; } = string.Empty;


        public override void ResetData()
        {
            RoleName = string.Empty;
        }
    }
}
using System.Collections.Generic;
using IO.Swagger.Model;

namespace AspApiSample.Web.Models.Admin
{
    public class RolesModel : ModelBase
    {
        public IEnumerable<Role> Roles { get; set; }
    }
}
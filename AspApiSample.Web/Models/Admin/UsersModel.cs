using System.Collections.Generic;
using IO.Swagger.Model;

namespace AspApiSample.Web.Models.Admin
{
    public class UsersModel : ModelBase
    {
        public IEnumerable<User> Users { get; set; }
    }
}
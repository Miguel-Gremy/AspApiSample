using System.Collections.Generic;

namespace AspApiSample.Web.Models.Admin
{
    public class IndexModel : ModelBase
    {
        public IEnumerable<string> Messages { get; set; }
    }
}
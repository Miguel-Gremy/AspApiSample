using System.Collections.Generic;

namespace AspApiSample.Web.Models
{
    public abstract class ModelBase
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
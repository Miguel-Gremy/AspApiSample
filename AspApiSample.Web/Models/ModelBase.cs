using System.Collections.Generic;

namespace AspApiSample.Web.Models
{
    public abstract class ModelBase
    {
        public ICollection<string> Errors { get; set; }
    }
}
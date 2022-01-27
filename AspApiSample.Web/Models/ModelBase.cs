using System.Collections.Generic;

namespace AspApiSample.Web.Models
{
    public abstract class ModelBase
    {
        public IEnumerable<string> Errors { get; set; }
        public IEnumerable<string> Messages { get; set; }

        public abstract void ResetData();
    }
}
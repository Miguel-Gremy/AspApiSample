namespace AspApiSample.Web.Models.Error
{
    public class ErrorViewModel : ModelBase
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);


        public override void ResetData()
        {
            
        }
    }
}
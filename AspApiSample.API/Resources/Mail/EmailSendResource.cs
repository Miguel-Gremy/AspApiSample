using System.ComponentModel.DataAnnotations;

namespace AspApiSample.API.Resources.Mail
{
    public class EmailSendResource
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string HtmlMessage { get; set; }
    }
}
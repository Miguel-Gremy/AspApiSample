using System.Threading.Tasks;
using AspApiSample.API.Resources.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public MailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> Send(EmailSendResource resource)
        {
            await _emailSender.SendEmailAsync(resource.Email, resource.Subject,
                resource.HtmlMessage);

            return Ok();
        }
    }
}
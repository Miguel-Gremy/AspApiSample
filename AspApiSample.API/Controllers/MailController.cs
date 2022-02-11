using System.Threading.Tasks;
using AspApiSample.API.Configuration;
using AspApiSample.API.Resources.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspApiSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<MailController> _logger;

        public MailController(IEmailSender emailSender, ILogger<MailController> logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> Send(EmailSendResource resource)
        {
            _logger.LogInformation(LogEvents.SendMail, LogMessages.SendMail, resource.Email);

            await _emailSender.SendEmailAsync(resource.Email, resource.Subject,
                resource.HtmlMessage);

            return Ok();
        }
    }
}
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace AspApiSample.API.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _fromMail;
        private readonly string _passwordMail;
        private readonly string _hostEmail;
        private readonly int _portEmail;

        public EmailSender(IConfiguration configuration)
        {
            _fromMail = configuration.GetSection("EmailParameters:From").Value;
            _passwordMail = configuration.GetSection("EmailParameters:Password").Value;
            _hostEmail = configuration.GetSection("EmailParameters:Host").Value;
            _portEmail = int.Parse(configuration.GetSection("EmailParameters:Port").Value ?? string.Empty);
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage(_fromMail, email, subject, htmlMessage)
            {
                IsBodyHtml = true,
            };

            new SmtpClient(_hostEmail, _portEmail)
            {
                Credentials = new NetworkCredential(_fromMail, _passwordMail),
            }.Send(message);

            return Task.CompletedTask;
        }
    }
}
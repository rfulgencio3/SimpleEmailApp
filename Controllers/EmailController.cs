using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace SimpleEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ahmed.hudson49@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("ahmed.hudson49@ethereal.email"));
            email.Subject = "Teste email subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ahmed.hudson49@ethereal.email", "bT3TG6EKN1RetnxWFq");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}

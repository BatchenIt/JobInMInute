using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace JobInMinuteServer.DAL.Interfaces
{
    public class EmailSender : IEmailSender
    {
        //    public Task SendEmailAsync(string email, string subject, string message)
        //    {
        //        var mail = "jklj26373@gmail.com";
        //        var pw = "ga1234567!!";
        //        var client = new SmtpClient("smtp.gmail.com", 587)
        //        {

        //            EnableSsl = true,
        //            UseDefaultCredentials = false,
        //            Credentials = new NetworkCredential(mail, pw)
        //        };

        //        return client.SendMailAsync(
        //            new MailMessage(from: mail,
        //                            to: email,
        //                            subject,
        //                            message
        //                            ));
        //    }
        //}
        private readonly SmtpClient _smtpClient;

        public EmailSender()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 465, // or the port used by your SMTP server
                Credentials = new NetworkCredential("jklj26373@gmail.com", "ga1234567!!"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false // Ensure credentials are used
                //EnableTls = true,
            };
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("jklj26373@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(to);

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}

using System.Net;
using System.Net.Mail;

namespace MailerApi.Infra.Services
{
    public class MailService : IMailService
    {
        private string _smtpAdress => "smtp.gmail.com";

        private int _portNumber => 587;

        private string _emailFromAddress => "email";

        private string _password => "senha";

        public void AddEmailsToMailMessage(MailMessage mailMessage, string[] emails)
        {
            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }
        }

        public void SendMail(string[] emails, string subject, string body, bool isHtml = false)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_emailFromAddress);
                AddEmailsToMailMessage(mailMessage, emails);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isHtml;
                using(SmtpClient smtp = new SmtpClient(_smtpAdress, _portNumber))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_emailFromAddress, _password);
                    smtp.Send(mailMessage);
                }
            }
        }
    }
}

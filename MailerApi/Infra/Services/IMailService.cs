
namespace MailerApi.Infra.Services
{
    public interface IMailService
    {
        public void SendMail(string[] emails, string subject, string body, bool isHtml = false);
    }
}

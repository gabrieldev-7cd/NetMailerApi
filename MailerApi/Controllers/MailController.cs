using MailerApi.Infra.Services;
using MailerApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailerApi.Controllers
{
    [Route("api/mails")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailservice)
        {
            _mailService = mailservice;
        }

        [HttpPost]
        public IActionResult SendMail([FromBody] SendMailViewModel sendMailViewModel)
        {
            _mailService.SendMail(
                sendMailViewModel.Emails,
                sendMailViewModel.Subject,
                sendMailViewModel.Body,
                sendMailViewModel.isHtml
            );

            return Ok();
        }
    }
}

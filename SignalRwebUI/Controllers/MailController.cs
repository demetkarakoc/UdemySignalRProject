using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRwebUI.Dtos.MailDtos;
using System.Net.Mail;


namespace SignalRwebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(CreateMailDto createMailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "projekursu@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.RecieveEmail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = createMailDto.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = createMailDto.Subject;

			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect("smptp.gmail.com", 587,false);
			smtp.Authenticate("projekursu@gmail.com", "key");

			smtp.Send(mimeMessage);
			smtp.Disconnect(true);

			return RedirectToAction("Index", "Category");

		}
	}
}

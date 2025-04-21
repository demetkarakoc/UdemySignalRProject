using Microsoft.AspNetCore.Mvc;

namespace SignalRwebUI.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ClientUserCount()
		{
			return View();
		}
	}
}

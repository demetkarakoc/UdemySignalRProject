using Microsoft.AspNetCore.Mvc;

namespace SignalRwebUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

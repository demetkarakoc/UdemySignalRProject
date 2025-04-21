using Microsoft.AspNetCore.Mvc;

namespace SignalRwebUI.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult NotFound404Page()
		{
			return View();
		}
	}
}

using Microsoft.AspNetCore.Mvc;

namespace SignalRwebUI.Controllers
{
	public class ProgressBarsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

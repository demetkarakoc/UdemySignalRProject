using Microsoft.AspNetCore.Mvc;

namespace SignalRwebUI.ViewComponents.DefaulltComponents
{
    public class _DefaultBookATableComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MyApiNightCase.WebUI.ViewComponents._AdminLayout
{
    public class _AdminLayoutHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

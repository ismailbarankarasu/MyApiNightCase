using Microsoft.AspNetCore.Mvc;

namespace MyApiNightCase.WebUI.ViewComponents._UserInterface
{
    public class _UserInterfaceHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

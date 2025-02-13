using Microsoft.AspNetCore.Mvc;

namespace MyApiNightCase.WebUI.ViewComponents._UserInterface
{
    public class _UserInterfaceScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

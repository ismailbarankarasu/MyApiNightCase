using Microsoft.AspNetCore.Mvc;

namespace MyApiNightCase.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

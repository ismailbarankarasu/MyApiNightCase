using Microsoft.AspNetCore.Mvc;

namespace MyApiNightCase.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

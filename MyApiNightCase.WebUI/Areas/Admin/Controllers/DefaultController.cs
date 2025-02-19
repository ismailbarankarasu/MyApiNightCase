using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApiNightCase.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize] 
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
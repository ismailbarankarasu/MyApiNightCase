using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.EntityLayer.Concrete;

namespace MyApiNightCase.WebUI.ViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminLayoutHeaderComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                ViewBag.UserName = user.UserName;
                ViewBag.ImageUrl = user.ImageUrl ?? "~/modernizedashboard/assets/images/profile/user-1.jpg";
            }
            return View();
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.EntityLayer.Concrete;
using MyApiNightCase.WebUI.Models;

namespace MyApiNightCase.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = (new RegisterViewModel(), new LoginViewModel());
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index([Bind(Prefix = "RegisterVM")] RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            System.Diagnostics.Debug.WriteLine($"Validation Error: {error.ErrorMessage}");
                        }
                    }
                    return View((model, new LoginViewModel()));
                }

                if (string.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("", "Şifre alanı boş bırakılamaz");
                    return View((model, new LoginViewModel()));
                }

                AppUser appUser = new AppUser()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    ImageUrl = "test"
                };

                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    System.Diagnostics.Debug.WriteLine($"Identity Error: {error.Description}");
                }
                return View((model, new LoginViewModel()));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
                ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                return View((model, new LoginViewModel()));
            }
        }
    }
}

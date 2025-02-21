using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.EntityLayer.Concrete;
using MyApiNightCase.WebUI.Models;

public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        var model = (new RegisterViewModel(), new LoginViewModel());
        return View("~/Views/Register/Index.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult> Index([Bind(Prefix = "LoginVM")] LoginViewModel model, string returnUrl = null)
    {
        try
        {
            // Debug için gelen model bilgilerini kontrol edelim
            System.Diagnostics.Debug.WriteLine($"Received UserName: {model?.UserName}");
            System.Diagnostics.Debug.WriteLine($"Received Password: {model?.Password}");

            if (model == null)
            {
                ModelState.AddModelError("", "Giriş bilgileri boş olamaz");
                return View("~/Views/Register/Index.cshtml", (new RegisterViewModel(), new LoginViewModel()));
            }

            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("", "Kullanıcı adı ve şifre gereklidir");
                return View("~/Views/Register/Index.cshtml", (new RegisterViewModel(), model));
            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password,
                isPersistent: false,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                System.Diagnostics.Debug.WriteLine("Login successful");
                return RedirectToAction("Index", "Default", new { area = "Admin" });
            }

            System.Diagnostics.Debug.WriteLine($"Login failed: {result}");
            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");
            return View("~/Views/Register/Index.cshtml", (new RegisterViewModel(), model));
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Login error: {ex.Message}");
            ModelState.AddModelError("", "Giriş sırasında bir hata oluştu");
            return View("~/Views/Register/Index.cshtml", (new RegisterViewModel(), model));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Login");
    }
    public IActionResult AccessDenied()
    {
        return View();
    }
}
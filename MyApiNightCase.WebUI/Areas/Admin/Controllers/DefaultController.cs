using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.WebUI.Dtos;
using Newtonsoft.Json;

namespace MyApiNightCase.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7104/api/Book/AllBookWithAuthorAndCategory");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var books = JsonConvert.DeserializeObject<List<BookWithAuthorAndCategory>>(jsonData);

                    var pageSize = 5;
                    var totalItems = books.Count;
                    var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                    var pagedBooks = books
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    ViewBag.CurrentPage = page;
                    ViewBag.TotalPages = totalPages;
                    ViewBag.TotalItems = totalItems;

                    return View(pagedBooks);
                }

                TempData["ErrorMessage"] = "Veriler alınamadı. Lütfen daha sonra tekrar deneyiniz.";
                return View(new List<BookWithAuthorAndCategory>());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
                return View(new List<BookWithAuthorAndCategory>());
            }
        }
    }
}
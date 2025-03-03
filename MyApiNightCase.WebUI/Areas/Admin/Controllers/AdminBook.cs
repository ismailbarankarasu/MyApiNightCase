using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.EntityLayer.Concrete;
using MyApiNightCase.WebUI.Dtos;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Text;

namespace MyApiNightCase.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminBook : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const int PageSize = 5;
        public AdminBook(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Login");

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7104/api/Book/BookWithAuthorListAndCategoryList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var allBooks = JsonConvert.DeserializeObject<List<BookWithAuthorListAndCategoryList>>(jsonData);

                var totalItems = allBooks.Count;
                var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
                var pagedBooks = allBooks.Skip((page - 1) * PageSize).Take(PageSize).ToList();

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = totalPages;
                ViewBag.TotalItems = totalItems;
                ViewBag.PageSize = PageSize;

                return View(pagedBooks);
            }
            return View(new List<BookWithAuthorListAndCategoryList>());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7104/api/Book?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Login");
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7104/api/Book/GetBook?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Book>(jsonData);

                var updateDto = new BookAddUpdateDto
                {
                    BookId = values.BookId,
                    Title = values.Title,
                    Price = values.Price,
                    ImageUrl = values.ImageUrl,
                    AuthorId = values.AuthorId,
                    CategoryId = values.CategoryId
                };

                return View(updateDto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookAddUpdateDto book)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(book);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7104/api/Book", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookAddUpdateDto book)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(book);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7104/api/Book", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}

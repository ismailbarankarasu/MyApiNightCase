using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.WebUI.Areas.Admin.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApiNightCase.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const int PageSize = 5;

        public AdminFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7104/api/Feature");
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<FeatureListViewModel>>();
                
                var totalItems = values.Count;
                var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
                var currentPageItems = values
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = totalPages;
                ViewBag.TotalItems = totalItems;
                ViewBag.PageSize = PageSize;

                return View(currentPageItems);
            }
            return View(new List<FeatureListViewModel>());
        }
    }
}

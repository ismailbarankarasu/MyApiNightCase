using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.WebUI.Dtos;
using Newtonsoft.Json;

namespace MyApiNightCase.WebUI.ViewComponents._AdminLayout
{
    public class _AdminLayoutCardComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminLayoutCardComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7104/api/Author/AuthorCount");
            var responseMessageForBookCount = await client.GetAsync("https://localhost:7104/api/Book/BookCount");
            var responseMessageForAvgBookPrice = await client.GetAsync("https://localhost:7104/api/Book/AvgBookPrice");
            var responseMessageForCategoryCount = await client.GetAsync("https://localhost:7104/api/Category/CategoryCount");
            if (responseMessage.IsSuccessStatusCode && responseMessageForBookCount.IsSuccessStatusCode 
                && responseMessageForCategoryCount.IsSuccessStatusCode && responseMessageForAvgBookPrice.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.AuthorCount = value;

                var jsonDataForBookCount = await responseMessageForBookCount.Content.ReadAsStringAsync();
                var valueForBookCount = JsonConvert.DeserializeObject<int>(jsonDataForBookCount);
                ViewBag.BookCount = valueForBookCount;

                var jsonDataForAvgBookPrice = await responseMessageForAvgBookPrice.Content.ReadAsStringAsync();
                var valueForAvgBookPrice = JsonConvert.DeserializeObject<double>(jsonDataForAvgBookPrice);
                ViewBag.AvgBookPrice = valueForAvgBookPrice;

                var jsonDataForCategoryCount = await responseMessageForCategoryCount.Content.ReadAsStringAsync();
                var valueForCategoryCount = JsonConvert.DeserializeObject<int>(jsonDataForCategoryCount);
                ViewBag.CategoryCount = valueForCategoryCount;
                return View(value);
            }
            return View();
        }
    }
}

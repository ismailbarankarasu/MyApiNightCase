using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.WebUI.Dtos;
using Newtonsoft.Json;

namespace MyApiNightCase.WebUI.ViewComponents._UserInterface
{
    public class _UserInterfaceProductsByCategoryComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserInterfaceProductsByCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7104/api/Book/AllBookWithAuthorAndCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<BookWithAuthorAndCategory>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}

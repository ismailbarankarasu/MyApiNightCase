using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.BusinessLayer.Abstract;
using MyApiNightCase.EntityLayer.Concrete;
using MyApiNightCase.WebApi.Dtos;

namespace MyApiNightCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryAddUpdateDto categoryDto)
        {
            var category = new Category
            {
                CategoryId = categoryDto.CategoryId,
                Name = categoryDto.Name
            };
            _categoryService.TInsert(category);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateCategory(CategoryAddUpdateDto categoryDto)
        {
            var category = new Category
            {
                CategoryId = categoryDto.CategoryId,
                Name = categoryDto.Name
            };
            _categoryService.TUpdate(category);
            return Ok("Güncelleme İşlemi Yapıldı");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var value = _categoryService.TCategoryCount();
            return Ok(value);
        }
    }
}

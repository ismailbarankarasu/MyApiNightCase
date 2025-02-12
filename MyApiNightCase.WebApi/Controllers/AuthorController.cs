using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.BusinessLayer.Abstract;
using MyApiNightCase.EntityLayer.Concrete;

namespace MyApiNightCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public IActionResult AuthorList()
        {
            var values = _authorService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            _authorService.TInsert(author);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int id) 
        {
            _authorService.TDelete(id);
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateAuthor(Author author)
        {
            _authorService.TUpdate(author);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpGet("GetAuthor")]
        public IActionResult GetAuthor(int id)
        {
            var value = _authorService.TGetById(id);
            return Ok(value);
        }
    }
}

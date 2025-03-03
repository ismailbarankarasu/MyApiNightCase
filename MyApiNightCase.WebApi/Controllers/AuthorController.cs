using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.BusinessLayer.Abstract;
using MyApiNightCase.EntityLayer.Concrete;
using MyApiNightCase.WebApi.Dtos;

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
        [HttpGet("AuthorList")]
        public IActionResult AuthorList()
        {
            var values = _authorService.TGetAll();
            return Ok(values);
        }
        [HttpPost("CreateAuthor")]
        public IActionResult CreateAuthor(AuthorAddUpdateDto authorDto)
        {
            var author = new Author
            {
                AuthorId = authorDto.AuthorId,
                NameSurname = authorDto.NameSurname,
                ImageUrl = authorDto.ImageUrl

            };
            _authorService.TInsert(author);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete("DeleteAuthor")]
        public IActionResult DeleteAuthor(int id) 
        {
            _authorService.TDelete(id);
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPut("UpdateAuthor")]
        public IActionResult UpdateAuthor(AuthorAddUpdateDto authorDto)
        {
            var author = new Author
            {
                AuthorId = authorDto.AuthorId,
                NameSurname = authorDto.NameSurname,
                ImageUrl = authorDto.ImageUrl
            };
            _authorService.TUpdate(author);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpGet("GetAuthor")]
        public IActionResult GetAuthor(int id)
        {
            var value = _authorService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("RandomFourAuthor")]
        public IActionResult RandomFourAuthor()
        {
            var values = _authorService.TRandomFourAuthor();
            return Ok(values);
        }
        [HttpGet("AuthorCount")]
        public IActionResult AuthorCount()
        {
            var value = _authorService.TAuthorCount();
            return Ok(value);
        }
    }
}

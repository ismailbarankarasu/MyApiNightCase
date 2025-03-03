using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.BusinessLayer.Abstract;
using MyApiNightCase.EntityLayer.Concrete;
using MyApiNightCase.WebApi.Dtos;

namespace MyApiNightCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult BookList()
        {
            var values = _bookService.TGetAll();
            return Ok(values);
        }
        [HttpPost("CreateBook")]
        public IActionResult CreateBook(BookAddUpdateDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Price = bookDto.Price,
                ImageUrl = bookDto.ImageUrl,
                AuthorId = bookDto.AuthorId,
                CategoryId = bookDto.CategoryId
            };

            _bookService.TInsert(book);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int id)
        { 
            _bookService.TDelete(id);
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(BookAddUpdateDto bookDto)
        {
            var book = new Book
            {
                BookId = bookDto.BookId,
                Title = bookDto.Title,
                Price = bookDto.Price,
                ImageUrl = bookDto.ImageUrl,
                AuthorId = bookDto.AuthorId,
                CategoryId = bookDto.CategoryId
            };

            _bookService.TUpdate(book);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpGet("GetBook")]
        public IActionResult GetBook(int id) 
        {
            var value = _bookService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("GetRandomBookWithAuthor")]
        public IActionResult GetRandomBookWithAuthor()
        {
            var values = _bookService.TGetRandomBookWithAuthor();
            return Ok(values);
        }
        [HttpGet("GetLastFourBooks")]
        public IActionResult GetLastFourBooks()
        {
            var value = _bookService.TGetLastFourBooks();
            return Ok(value);
        }
        [HttpGet("AllBookWithAuthorAndCategory")]
        public IActionResult AllBookWithAuthorAndCategory()
        {
            var values = _bookService.TAllBookWithAuthorAndCategory();
            return Ok(values);
        }
        [HttpGet("BookCount")]
        public IActionResult BookCount()
        {
            var value = _bookService.TBookCount();
            return Ok(value);
        }
        [HttpGet("AvgBookPrice")]
        public IActionResult AvgBookPrice()
        {
            var value = _bookService.TAvgBookPrice();
            return Ok(value);
        }
        [HttpGet("BookWithAuthorListAndCategoryList")]
        public IActionResult BookWithAuthorListAndCategoryList()
        {
            var values = _bookService.TAllBookWithAuthorListAndCategoryList();
            return Ok(values);
        }
    }
}

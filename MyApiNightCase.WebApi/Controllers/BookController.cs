﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiNightCase.BusinessLayer.Abstract;
using MyApiNightCase.EntityLayer.Concrete;

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
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _bookService.TInsert(book);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        { 
            _bookService.TDelete(id);
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
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
    }
}

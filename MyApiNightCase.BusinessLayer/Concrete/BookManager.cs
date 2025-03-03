using MyApiNightCase.BusinessLayer.Abstract;
using MyApiNightCase.DataAccessLayer.Abstract;
using MyApiNightCase.DataAccessLayer.Dtos;
using MyApiNightCase.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.BusinessLayer.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public List<BookWithAuthorAndCategory> TAllBookWithAuthorAndCategory()
        {
            return _bookDal.AllBookWithAuthorAndCategory();
        }

        public List<BookWithAuthorListAndCategoryList> TAllBookWithAuthorListAndCategoryList()
        {
            return _bookDal.AllBookWithAuthorListAndCategoryList();
        }

        public double TAvgBookPrice()
        {
            return _bookDal.AvgBookPrice();
        }

        public int TBookCount()
        {
            return _bookDal.BookCount();
        }

        public void TDelete(int id)
        {
            _bookDal.Delete(id);
        }

        public List<Book> TGetAll()
        {
            return _bookDal.GetAll();
        }

        public Book TGetById(int id)
        {
            return _bookDal.GetById(id);
        }

        public List<LastFourBookWithAuthorDto> TGetLastFourBooks()
        {
            return _bookDal.GetLastFourBooks();
        }

        public BookWithAuthorDto TGetRandomBookWithAuthor()
        {
            return _bookDal.GetRandomBookWithAuthor();
        }

        public void TInsert(Book entity)
        {
            _bookDal.Insert(entity);
        }

        public void TUpdate(Book entity)
        {
            _bookDal.Update(entity);
        }
    }
}

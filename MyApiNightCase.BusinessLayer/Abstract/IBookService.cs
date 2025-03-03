using MyApiNightCase.DataAccessLayer.Dtos;
using MyApiNightCase.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.BusinessLayer.Abstract
{
    public interface IBookService : IGenericService<Book>
    {
        public BookWithAuthorDto TGetRandomBookWithAuthor();
        public List<LastFourBookWithAuthorDto> TGetLastFourBooks();
        public List<BookWithAuthorAndCategory> TAllBookWithAuthorAndCategory();
        public int TBookCount();
        public double TAvgBookPrice();
        public List<BookWithAuthorListAndCategoryList> TAllBookWithAuthorListAndCategoryList();
    }
}

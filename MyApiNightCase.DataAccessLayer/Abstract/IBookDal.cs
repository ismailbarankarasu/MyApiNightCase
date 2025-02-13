using MyApiNightCase.DataAccessLayer.Dtos;
using MyApiNightCase.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.DataAccessLayer.Abstract
{
    public interface IBookDal : IGenericDal<Book>
    {
        public BookWithAuthorDto GetRandomBookWithAuthor();
        public List<LastFourBookWithAuthorDto> GetLastFourBooks();
        public List<BookWithAuthorAndCategory> AllBookWithAuthorAndCategory();
    }
}

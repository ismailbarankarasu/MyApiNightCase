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
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public int TAuthorCount()
        {
            return _authorDal.AuthorCount();
        }

        public void TDelete(int id)
        {
            _authorDal.Delete(id);
        }

        public List<Author> TGetAll()
        {
            return _authorDal.GetAll();
        }

        public Author TGetById(int id)
        {
            return _authorDal.GetById(id);
        }

        public void TInsert(Author entity)
        {
            _authorDal.Insert(entity);
        }

        public List<ResultAuthorDto> TRandomFourAuthor()
        {
            return  _authorDal.RandomFourAuthor();
        }

        public void TUpdate(Author entity)
        {
            _authorDal.Update(entity);
        }
    }
}

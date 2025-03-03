using MyApiNightCase.DataAccessLayer.Dtos;
using MyApiNightCase.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.DataAccessLayer.Abstract
{
    public interface IAuthorDal : IGenericDal<Author>
    {
        public List<ResultAuthorDto> RandomFourAuthor();
        public int AuthorCount();
    }
}

using MyApiNightCase.DataAccessLayer.Dtos;
using MyApiNightCase.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.BusinessLayer.Abstract
{
    public interface IAuthorService : IGenericService<Author>
    {
        public List<ResultAuthorDto> TRandomFourAuthor();
    }
}

using MyApiNightCase.DataAccessLayer.Abstract;
using MyApiNightCase.DataAccessLayer.Context;
using MyApiNightCase.DataAccessLayer.Repository;
using MyApiNightCase.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.DataAccessLayer.EntityFramework
{
    public class EfAuthorDal : GenericRepository<Author>, IAuthorDal
    {
        public EfAuthorDal(ApiCaseContext context) : base(context)
        {
        }
    }
}

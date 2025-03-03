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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly ApiCaseContext context;
        public EfCategoryDal(ApiCaseContext _context) : base(_context)
        {
            context = _context;
        }

        public int CategoryCount()
        {
            var value = context.Categories.Count();
            return value;
        }
    }
}

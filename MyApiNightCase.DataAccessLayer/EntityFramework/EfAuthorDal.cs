using Microsoft.EntityFrameworkCore;
using MyApiNightCase.DataAccessLayer.Abstract;
using MyApiNightCase.DataAccessLayer.Context;
using MyApiNightCase.DataAccessLayer.Dtos;
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
        private readonly ApiCaseContext context;
        public EfAuthorDal(ApiCaseContext _context) : base(_context)
        {
            context = _context;
        }

        public int AuthorCount()
        {
            var authorCount = context.Authors.Count();
            return authorCount;
        }

        public List<ResultAuthorDto> RandomFourAuthor()
        {
            var randomAuthors = context.Authors
             .OrderBy(a => Guid.NewGuid())
             .Take(4)
             .Select(a => new ResultAuthorDto
                 {
                   NameSurname = a.NameSurname,
                   ImageUrl = a.ImageUrl
                 })
             .ToList();
            return randomAuthors;
        }
    }
}

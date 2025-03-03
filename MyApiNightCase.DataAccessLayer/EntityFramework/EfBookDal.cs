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
    public class EfBookDal : GenericRepository<Book>, IBookDal
    {
        private readonly ApiCaseContext context;
        public EfBookDal(ApiCaseContext _context) : base(_context)
        {
            context = _context;
        }

        public List<BookWithAuthorAndCategory> AllBookWithAuthorAndCategory()
        {
            var values = context.Books
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Select(a => new BookWithAuthorAndCategory
            {
                    BookTitle = a.Title,
                    AuthorName = a.Author.NameSurname,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price,
                    CategoryName = a.Category.Name
                }).ToList();
            return values;
        }

        public List<BookWithAuthorListAndCategoryList> AllBookWithAuthorListAndCategoryList()
        {
            var values = context.Books
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Select(a => new BookWithAuthorListAndCategoryList
                {
                    BookId = a.BookId,
                    BookTitle = a.Title,
                    AuthorId = a.AuthorId,
                    AuthorName = a.Author.NameSurname,
                    Price = a.Price,
                    CategoryId = a.CategoryId,
                    CategoryName = a.Category.Name,
                    ImageUrl= a.ImageUrl
                }).ToList();
            return values;
        }

        public double AvgBookPrice()
        {
            var averagePrice = context.Books.Average(x => (double)x.Price);
            return Math.Round(averagePrice, 2);
        }

        public int BookCount()
        {
            var bookCount = context.Books.Count();
            return bookCount;
        }

        public List<LastFourBookWithAuthorDto> GetLastFourBooks()
        {
            var values = context.Books
                .Include(y => y.Author)
                .OrderByDescending(x => x.BookId)
                .Take(4)
                .Select(z => new LastFourBookWithAuthorDto
                {
                    BookTitle = z.Title,
                    AuthorName = z.Author.NameSurname,
                    Price = z.Price,
                    ImageUrl = z.ImageUrl
                })
                .ToList();
            return values;
        }

        public BookWithAuthorDto GetRandomBookWithAuthor()
        {
            var randomBook = context.Books
                                .Include(b => b.Author)
                                .OrderBy(x => Guid.NewGuid())
                                .Take(1)
                                .Select(b => new BookWithAuthorDto
                                {
                                    BookTitle = b.Title,
                                    AuthorName = b.Author.NameSurname,
                                    Price = b.Price,
                                    ImageUrl = b.ImageUrl
                                })
                                .FirstOrDefault();

            return randomBook;
        }
    }
}

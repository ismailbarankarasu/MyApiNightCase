using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.DataAccessLayer.Dtos
{
    public class BookWithAuthorAndCategory
    {
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}

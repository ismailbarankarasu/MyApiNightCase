using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.EntityLayer.Concrete
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title{ get; set; }
        public decimal Price{ get; set; }
        public string ImageUrl { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

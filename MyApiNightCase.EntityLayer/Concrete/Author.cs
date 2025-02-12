using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.EntityLayer.Concrete
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public List<Book> Books { get; set; }
    }
}

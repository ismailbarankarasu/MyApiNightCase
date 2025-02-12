using Microsoft.EntityFrameworkCore;
using MyApiNightCase.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNightCase.DataAccessLayer.Context
{
    public class ApiCaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AV376HC\\SQLEXPRESS;initial Catalog=ApiCaseDbNight;integrated Security=true");
        }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Book> Books{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Feature> Features{ get; set; }
    }
}

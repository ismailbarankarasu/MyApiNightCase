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
        public ApiCaseContext(DbContextOptions<ApiCaseContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors{ get; set; }
        public DbSet<Book> Books{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Feature> Features{ get; set; }
        public DbSet<User>Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category - Book (1 Category -> ∞ Books)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Eğer kategori silinirse, kitaplar da silinir.

            // Author - Book (1 Author -> ∞ Books)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); // Eğer yazar silinirse, kitaplar da silinir.

            base.OnModelCreating(modelBuilder);
        }
    }
}

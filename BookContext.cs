using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEntry_FluentAPI
{
    class BookContext : DbContext
    {
        //public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        private const string connectionString = "Data Source=DESKTOP-KHL9E1P\\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var books = modelBuilder.Entity<Book>();

            books.Property(x => x.BookName).IsRequired();
            books.Property(b => b.BookPrice).HasColumnType("decimal(5,2)");
            books.Property(b => b.BookName).HasMaxLength(30);
        }

        public DbSet<Book> Books { get; set; }
    }
}

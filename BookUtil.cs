using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEntry_FluentAPI
{
    internal class BookUtil
    {

        public void AddBook(Book book)
        {
            using (var bookContext = new BookContext())
            {
                bookContext.Books.Add(book);
                bookContext.SaveChanges();
            }
        }

        public List<Book> GetBooksList()
        {
            var bookContext= new BookContext();
            return bookContext.Books.ToList();
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            var bookContext = new BookContext();
            return bookContext.Books.Where(x => x.BookGenre == genre).ToList();
        }

        public Book UpdateBook(double NewPrice,int BookId)
        {
            var bookContext = new BookContext();
            var book = bookContext.Books.FirstOrDefault(x => x.BookId == BookId);

            book.BookPrice = NewPrice;
            bookContext.SaveChanges();

            return book;
        }

        public Book DeleteBook(int BookId)
        {
            var bookContext = new BookContext();
            var book = bookContext.Books.Find(BookId);

            bookContext.Books.Remove(book);
            bookContext.SaveChanges();

            return book;
        }
    }
}

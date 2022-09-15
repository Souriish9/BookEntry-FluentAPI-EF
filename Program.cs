using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEntry_FluentAPI
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("--------BOOKS STORE---------");
                Console.WriteLine("Press 1 to Add Book");
                Console.WriteLine("Press 2 to Get All Book");
                Console.WriteLine("Press 3 to Get Book By Genre");
                Console.WriteLine("Press 4 to Update Book");
                Console.WriteLine("Press 5 to Delete Book");

                int choice= Convert.ToByte(Console.ReadLine());
                BookUtil bookUtil=new BookUtil();
                Book book=new Book();

                switch(choice)
                {
                    case 1: Console.WriteLine("ADD BOOK SERVICE");
                            Console.WriteLine(" ");
                            Console.WriteLine("Enter Bookname:");
                            book.BookName = Console.ReadLine();
                            Console.WriteLine("Enter Author Name:");
                            book.BookAuthor = Console.ReadLine();
                            Console.WriteLine("Enter Genre:");
                            book.BookGenre = Console.ReadLine();
                            Console.WriteLine("Enter Book Price:");
                            book.BookPrice = Convert.ToDouble(Console.ReadLine());
                            bookUtil.AddBook(book);
                        Console.WriteLine("Book Added Successfully!");
                        Console.WriteLine(" ");
                            break;

                    case 2: Console.WriteLine("GET ALL BOOK SERVICE");
                            var res = bookUtil.GetBooksList();
                            
                            for(int i=0;i<res.Count();i++)
                            {
                                Console.WriteLine("Book "+(i+1)+":");
                                Console.WriteLine("Book Name: "+res[i].BookName);
                                Console.WriteLine("Author: "+res[i].BookAuthor);
                                Console.WriteLine("Genre: "+res[i].BookGenre);
                                Console.WriteLine("Price: "+res[i].BookPrice);
                                Console.WriteLine(" ");
                            }
                        Console.WriteLine("-----------------");
                            break;

                    case 3: Console.WriteLine("GET BOOOK BY GENRE");
                        Console.WriteLine("-------------");
                        Console.WriteLine("Enter Genre: ");
                        string genre = Console.ReadLine();
                        res = bookUtil.GetBooksByGenre(genre);

                        foreach(var item in res)
                        {
                            Console.WriteLine("-----Book ID:"+ item.BookId);
                            Console.WriteLine(item.BookName);
                            Console.WriteLine(item.BookAuthor);
                            Console.WriteLine(item.BookPrice);
                            Console.WriteLine("");
                        }
                        Console.WriteLine("---------------------------------");
                            break;

                    case 4: Console.WriteLine("UPDATE BOOK SERVICE");
                        Console.WriteLine("Enter Book ID: ");
                        int Id=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter New Price: ");
                        double np = Convert.ToDouble(Console.ReadLine());
                        book = bookUtil.UpdateBook(np, Id);
                        Console.WriteLine(" ");
                        Console.WriteLine("UPDATED BOOK DETAILS");
                        Console.WriteLine(book.BookName);
                        Console.WriteLine(book.BookPrice);
                        Console.WriteLine("--------------------------------------");
                        break;

                    case 5: Console.WriteLine("DELETE BOOK SERVICE");
                        Console.WriteLine("Enter the ID to Delete:");
                        Id= Convert.ToInt32(Console.ReadLine());
                        book = bookUtil.DeleteBook(Id);
                        Console.WriteLine(" ");
                        Console.WriteLine("DELETED BOOK DETAILS");
                        Console.WriteLine(book.BookId);
                        Console.WriteLine(book.BookName);
                        Console.WriteLine(book.BookAuthor);
                        Console.WriteLine(book.BookPrice);
                        Console.WriteLine("--------------------------------------");
                        break;
                    default: Console.WriteLine("WRONG ENTRY");
                            break;
                }

            }
        }
    }
}

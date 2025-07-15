using System;
using System.Collections.Generic;

namespace BookManager
{
    class Program
    {
        static void Main(string[] args)
        {
            List<_Book> bookCollection = new List<_Book>
            {
                new _FictionBook("The Hobbit", "J.R.R. Tolkien", "Fantasy"),
                new _NonFictionBook("Educated", "Tara Westover", "Memoir"),
                new _PoetryBook("Milk and Honey", "Rupi Kaur", 204),
                new _FictionBook("1984", "George Orwell", "Dystopian"),
                new _NonFictionBook("Sapiens", "Yuval Noah Harari", "History")
            };

            Console.WriteLine("📚 Book Collection:\n");

            foreach (_Book book in bookCollection)
            {
                book.DisplayDetails();
            }
        }
    }
}

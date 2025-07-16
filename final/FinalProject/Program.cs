using System;
using System.Collections.Generic;

namespace BookManager
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookCollection = new List<Book>
            {
                new FictionBook("The Hobbit", "J.R.R. Tolkien", "Fantasy"),
                new NonFictionBook("Educated", "Tara Westover", "Memoir"),
                new PoetryBook("Milk and Honey", "Rupi Kaur", 204),
                new FictionBook("1984", "George Orwell", "Dystopian"),
                new NonFictionBook("Sapiens", "Yuval Noah Harari", "History")
            };

            Console.WriteLine("📚 Book Collection:\n");

            foreach (Book book in bookCollection)
            {
                book.DisplayDetails();
            }
        }
    }
}

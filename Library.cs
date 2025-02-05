using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract11_2_Shengals
{
    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book) => books.Add(book);

        public void RemoveBook(Book book) => books.Remove(book);

        public List<Book> FindByAuthor(string author) => books.FindAll(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));

        public List<Book> FindByYear(int year) => books.FindAll(b => b.Year == year);

        public void SortByTitle()
        {
            books.Sort((a, b) => a.Title.CompareTo(b.Title));
        }

        public void SortByAuthor()
        {
            books.Sort((a, b) => a.Author.CompareTo(b.Author));
        }

        public void SortByYear()
        {
            books.Sort((a, b) => a.Year.CompareTo(b.Year));
        }

        public List<Book> GetAllBooks() => new List<Book>(books);
    }
}

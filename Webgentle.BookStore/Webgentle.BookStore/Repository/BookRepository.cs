using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title , string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title)  && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
            new BookModel() {Id=1 , Title="MVC" , Author="Shivam"},
            new BookModel() { Id = 2, Title = "Dot Net Core", Author = "morphy" },
            new BookModel() { Id = 3, Title = "JAVA", Author = "richards" },
            new BookModel() { Id = 4, Title = "PHP", Author = "shawn " },
            new BookModel() { Id = 5, Title = "C#", Author = "laura " },
            };
        }
    }
}

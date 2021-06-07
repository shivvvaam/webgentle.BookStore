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
            new BookModel() { Id=1 ,  Title="MVC" ,  Author="Shivam", Description="This is for desciption of MVC book",Category="Programming" ,Language="English", TotalPages=134 },
            new BookModel() { Id = 2, Title = "Dot Net Core", Author = "morphy" ,Description="This is for desciption of Dot Net Core book",Category="Framwork" ,Language="Chinese", TotalPages=567 },
            new BookModel() { Id = 3, Title = "JAVA", Author = "richards",Description="This is for desciption of JAVA book",Category="Developer" ,Language="English", TotalPages=97 },
            new BookModel() { Id = 4, Title = "PHP", Author = "shawn ",Description="This is for desciption of PHP book",Category="Concept" ,Language="English", TotalPages=564 },
            new BookModel() { Id = 5, Title = "C#", Author = "laura ",Description="This is for desciption of C# book" ,Category="Programming" ,Language="English", TotalPages=100},
            new BookModel() { Id = 6, Title = "Azure Devops", Author = "Miranda ",Description="This is for desciption of Azure Devops book",Category="DevOps" ,Language="English", TotalPages=800 },
            };
        }
    }
}

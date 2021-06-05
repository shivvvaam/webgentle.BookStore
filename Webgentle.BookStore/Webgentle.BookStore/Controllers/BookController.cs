using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;
        public BookController() 
        {
            bookRepository = new BookRepository();
        } 
        public ViewResult GetAllBooks()
        {
            var data= bookRepository.GetAllBooks();
            return View();
        }
        public BookModel GetBook(int id)
        {
            return bookRepository.GetBookById(id);
        }
        public List<BookModel> SearchBooks(string bookName , string authorName)
        {
            return bookRepository.SearchBook(bookName, authorName);
        }
    }
}

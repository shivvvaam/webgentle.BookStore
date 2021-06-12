using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository) 
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }

        public async Task<ViewResult> Getallbooks()
        {
            var data=await _bookRepository.GetAllBooks();
            return View(data);
        }

      //  [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data=await _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName , string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }
        //get method
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId=0)
        {
            var model = new BookModel()
            {
              //  Language = "2"
            };

            ViewBag.Language =new SelectList( await _languageRepository.GetLanguages(),"Id","Name");

            //ViewBag.Language = new SelectList(GetLanguage(),"Id","Text");

            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem() 
            //{
            //    Text=x.Text,
            //    Value=x.Id.ToString()

            //}).ToList();

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Hindi", Value="1" },
            //    new SelectListItem(){Text="English", Value="2" },
            //    new SelectListItem(){Text="Dutch", Value="3"},
            //    new SelectListItem(){Text="Tamil", Value="4"},
            //    new SelectListItem(){Text="Urdu", Value="5"},
            //    new SelectListItem(){Text="Frenach", Value="6"},
            //};


            ViewBag.IsSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        
        {
            if(ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");


            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Hindi", Value="1" },
            //    new SelectListItem(){Text="English", Value="2" },
            //    new SelectListItem(){Text="Dutch", Value="3"},
            //    new SelectListItem(){Text="Tamil", Value="4"},
            //    new SelectListItem(){Text="Urdu", Value="5"},
            //    new SelectListItem(){Text="Frenach", Value="6"},
            //};
            return View();
        }
        //private List<LanguageModel> GetLanguage()
        //{
        //    return new List<LanguageModel>()
        //    {
        //        new LanguageModel(){Id=1 , Text= "Hindi"},
        //        new LanguageModel(){Id=2 , Text= "English"},
        //        new LanguageModel(){Id=3 , Text= "French"},
        //    };
        //}
    }
}

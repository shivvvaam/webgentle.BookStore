using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Service;

namespace Webgentle.BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(
           IUserService userService)
        {
            
            _userService = userService;
        }


        public ViewResult Index()
        {
            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}

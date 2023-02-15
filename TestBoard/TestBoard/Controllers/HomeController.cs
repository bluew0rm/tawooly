using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using TestBoard.Models;

namespace TestBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Tawooly()
        {
            return View();
        }

        public IActionResult Introduction()
        {
            return View();
        }

        public IActionResult Board()
        {
            return View();
        }

        public IActionResult Management()
        {
            return View();
        }

        public IActionResult ToDoList()
        {
            return View();
        }

    }
}

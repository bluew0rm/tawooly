﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamplePage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Management()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ToDoList()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
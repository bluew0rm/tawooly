using Project_Board.Models;
using Project_Board.Service.Adepter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Project_Board.Controllers
{
    public class BoardController : Controller
    {
        
        CallData boardAdepter = new CallData();
        DataTable itemTable = new DataTable();

        public ActionResult Index()
        {
            boardAdepter.Index(itemTable);

            return View(itemTable);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AllDelete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SingleDelete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Detail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pageing()
        {
            boardAdepter.Paging(itemTable);

            return View(itemTable);
        }
    }
}
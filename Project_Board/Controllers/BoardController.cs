using Project_Board.Models;
using Project_Board.Service.Adepter;
using Project_Board.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Project_Board.Controllers
{
    public class BoardController : Controller
    {
        private BoardService _boardService;
        private BoardService service { get {  if (_boardService == null) { _boardService = new BoardService(); } return _boardService; } }
       
        DataTable itemTable = new DataTable();

        public ActionResult Index()
        {
            service.GetAllData();

            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            var title = Request.Form["_title"];
            var text = Request.Form["_text"];
            var writer = Request.Form["_writer"];
            var date = Request.Form["_date"];

            service.Create(title, text, writer, date);

            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult AllDelete()
        {
            service.AllDelete();

            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult SingleDelete()
        {
            var id = Request.Form["_id"];
            service.SingleDelete(id);

            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult Detail()
        {
            var id = this.Request.Form["_id"];

            service.GetDetailById(id);

            return View(itemTable);
        }

        [HttpPost]
        public ActionResult Update()
        {
            var title = Request.Form["_title"];
            var writer = Request.Form["_Writer"];
            var update = Request.Form["_Update"];
            var text = Request.Form["_Text"];

            var item = new BoardItem(int.Parse(id.ToString()), title, writer, update, text);

            service.Update(item);

            return Redirect("Index");
        }

            var id = Request.Form["_id"];
        [HttpPost]
        public ActionResult Search()
        {
            string title = Request.Form["_searchTitle"];
            boardAdepter.Search(title, itemTable);

            return View(itemTable);
        }

        [HttpPost]
        public ActionResult Pageing()
        {
            service.Get(itemTable);

            return Redirect("Index");
        }
    }
}
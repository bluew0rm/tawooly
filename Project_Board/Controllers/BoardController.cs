using Microsoft.Ajax.Utilities;
using Project_Board.Controllers.APIController;
using Project_Board.Models;
using Project_Board.Services;
using System.Data;
using System;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Web.Http;

namespace Project_Board.Controllers
{
    public class BoardController : Controller
    {
        private BoardService _boardService;
        private BoardService service { get {  if (_boardService == null) { _boardService = new BoardService(); } return _boardService; } }
       
        DataTable itemTable = new DataTable();
        BoardApiController post = new BoardApiController();

        //SelectAll ok
        public ActionResult Index()
        {
            var result = service.GetAllData();

            return View(result);
        }

        //Create
        public ActionResult Create([FromBody] BoardItem item)
        {
            service.Create(item);
            return Redirect("Index");
        }

        //AllDelete  ok 
        [System.Web.Mvc.HttpPost]
        public ActionResult AllDelete()
        {
            service.AllDelete();

            return Redirect("Index");
        }

        //Delete  ok
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete()
        {
            var id = Request.Form["_id"];

            service.GetDeleteById(id);

            return Redirect("Index");
        }

        //Detail  ok
        [System.Web.Mvc.HttpPost]
        public ActionResult Detail()
        {
            var id = this.Request.Form["_id"];

            var result = service.GetDetailById(id);

            return View(result);
        }

        //Update  ok
        [System.Web.Mvc.HttpPost]
        public ActionResult Update(BoardItem item)
        {
            service.Update(item);

            return View("Index");
        }

        //Search
        /*[System.Web.Mvc.HttpPost]
        public ActionResult Search(BoardItem item)
        {
            var result = post.Search(item);

            return Redirect("Index");
        }*/

        /*[HttpPost]
        public ActionResult Pageing()
        {
            service.Get(itemTable);

            return Redirect("Index");
        }*/
    }
}
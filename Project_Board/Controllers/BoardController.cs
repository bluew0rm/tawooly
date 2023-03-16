using Project_Board.Models;
using Project_Board.Models.Search;
using Project_Board.Services;
using System.Data;
using System.Web.Mvc;

namespace Project_Board.Controllers
{
    public class BoardController : Controller
    {
        private BoardService _boardService;
        private BoardService service { get {  if (_boardService == null) { _boardService = new BoardService(); } return _boardService; } }
       
        DataTable itemTable = new DataTable();

        //SelectAll ok
        public ActionResult Index()
        {
            var result = service.GetAllData();

            return View(result);
        }

        //Create
        [HttpPost]
        public ActionResult Create()
        {
            var title = Request.Form["_title"];
            var writer = Request.Form["_writer"];
            var update = Request.Form["_date"];
            var text = Request.Form["_text"];
            
            var item = new BoardItem(title, text, writer, update);

            service.Create(item);

            return Redirect("Index");
        }

        //AllDelete  ok 
        [HttpPost]
        public ActionResult AllDelete()
        {
            service.AllDelete();

            return Redirect("Index");
        }

        //Delete  ok
        [HttpPost]
        public ActionResult Delete()
        {
            var id = Request.Form["_id"];

            service.GetDeleteById(id);

            return Redirect("Index");
        }

        //Detail  ok
        [HttpPost]
        public ActionResult Detail()
        {
            var id = this.Request.Form["_id"];

            var result = service.GetDetailById(id);

            return View(result);
        }

        //Update  ok
        [HttpPost]
        public ActionResult Update()
        {
            var id = this.Request.Form["_id"];
            var title = this.Request.Form["_title"];
            var writer = this.Request.Form["_Writer"];
            var update = this.Request.Form["_Update"];
            var text = this.Request.Form["_Text"];

            var item = new BoardItem(int.Parse(id.ToString()), title, writer, update, text);

            service.Update(item);

            return Redirect("Index");
        }

        //Search
        [HttpPost]
        public ActionResult Search()
        {
            var title = Request.Form["_searchTitle"];


            var item = new SearchBoardItem(title);

            var result = service.Search(item);

            return View(result);
        }

        /*[HttpPost]
        public ActionResult Pageing()
        {
            service.Get(itemTable);

            return Redirect("Index");
        }*/
    }
}
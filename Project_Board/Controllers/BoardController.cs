using Project_Board.Controllers.APIController;
using Project_Board.Models;
using Project_Board.Services;
using System.Data;
using System.Web.Mvc;
using System.Web.Http;
using Project_Board.Models.Search;

namespace Project_Board.Controllers
{
    public class BoardController : Controller
    {
        private BoardService _boardService;
        private BoardService service { get { if (_boardService == null) { _boardService = new BoardService(); } return _boardService; } }

        DataTable itemTable = new DataTable();
        BoardApiController post = new BoardApiController();

        //SelectAll ok
        public ActionResult Index()
        {
            var result = service.GetAllData();
            return View(new DataTable());
        }

        //Create
        [System.Web.Mvc.HttpPost]
        public string Create([FromBody] BoardItem item)
        {
            return service.Create(item); //string json
        }

        //DeleteAll
        [System.Web.Mvc.HttpPost]
        public ActionResult DeleteAll()
        {
            service.DeleteAll();
            return RedirectToAction("Index");
        }

        //Delete  ok
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete()
        {
            var itemId = Request.Form["_id"];

            service.DeleteById(itemId);

            return RedirectToAction("Index");
        }

        //Detail  ok
        [System.Web.Mvc.HttpPost]
        public string Detail([FromBody] BoardItem item)
        {
            return service.GetDetailById(item); //string json
        }

        //Update  ok
        [System.Web.Mvc.HttpPost]
        public ActionResult Update(BoardItem item)
        {
            service.Update(item);

            return View("Index");
        }

        //Search
        [System.Web.Mvc.HttpPost]
        public string Search([FromBody] SearchCondition searchCondition)
        {
            return service.Search(searchCondition); //string json
        }

        /*[HttpPost]
        public ActionResult Pageing()
        {
            service.Get(itemTable);

            return Redirect("Index");
        }*/
    }
}
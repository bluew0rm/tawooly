using Project_Board.Controllers.APIController;
using Project_Board.Models;
using Project_Board.Services;
using System.Data;
using System.Web.Mvc;
using System.Web.Http;
using Project_Board.Models.Search;
using Project_Board.Models.Paging;

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
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public string Paging([FromBody] PagingInfo page)
        {
            var result = service.GetFirstData(page);
            return result;
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
            var itemId = Request.Form["id"];

            service.DeleteById(itemId);

            return RedirectToAction("Index");
        }

        //Update  ok
        [System.Web.Mvc.HttpPost]
        public ActionResult Detail()
        {
            var itemId = Request.Form["_id"];

            var result = service.Detail(itemId);

            return View(result);
        }

        //Update  ok
        [System.Web.Mvc.HttpPost]
        public string Update([FromBody] BoardItem item)
        {            
            return service.Update(item); ;
        }

        //Search
        [System.Web.Mvc.HttpPost]
        public string Search([FromBody] SearchCondition searchCondition, PagingInfo pagingInfo)
        {
            return service.Search(new PageAndItemData(searchCondition, pagingInfo)); //string json
        }
        /*[HttpPost]
        public ActionResult Pageing()
        {
            service.Get(itemTable);

            return Redirect("Index");
        }*/
    }
}
using Project_Board.Models;
using System.Web.Http;
using System.Web.Mvc;
using Project_Board.Services;
using System.Data;


namespace Project_Board.Controllers.APIController
{
    public class BoardApiController : ApiController
    {
        private BoardService _boardService;
        private BoardService service { get { if (_boardService == null) { _boardService = new BoardService(); } return _boardService; } }

        
        [System.Web.Mvc.HttpPost]
        //Create : POST api/<controller>
        public DataTable Search([FromBody] BoardItem item)
        {
            var items = service.Search(item);

            return items;
        }


    }
}

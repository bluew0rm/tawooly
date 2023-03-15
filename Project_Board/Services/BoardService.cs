using Project_Board.Models;
using Project_Board.Service.Adepter;
using System.Data;

namespace Project_Board.Services
{
    public class BoardService
    {
        private PostBoardAdapter _postBoardAdapter;

        private PostBoardAdapter Adapter { get { if (_postBoardAdapter == null) { _postBoardAdapter = new PostBoardAdapter(); } return _postBoardAdapter; } }


        public BoardItem GetAllData()
        {
            var dataTable = Adapter.GetDataByAll();

            var result = new BoardItem(dataTable); 
            
            return result;
        }


        public BoardItem GetDetailById(string id)
        {
            var dataTable = Adapter.GetDataById(id);

            var result = new BoardItem(dataTable);

            return result;
        }

        public void Update(BoardItem item)
        {
            Adapter.Update(item);
        }


    }
}
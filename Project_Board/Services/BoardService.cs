using Newtonsoft.Json;
using Project_Board.Models;
using Project_Board.Models.Search;
using Project_Board.Service.Adepter;
using System.Collections.Generic;
using System.Data;
using System.Net.Cache;
using System.Web.Mvc;



namespace Project_Board.Services
{
    public class BoardService
    {
        private PostBoardAdapter _postBoardAdapter;

        private PostBoardAdapter Adapter { get { if (_postBoardAdapter == null) { _postBoardAdapter = new PostBoardAdapter(); } return _postBoardAdapter; } }

        //SelectAll ok
        public DataTable GetAllData()
        {
            DataTable dataTable = Adapter.GetDataByAll();

            return dataTable;
        }

        //Update  ok
        public DataTable Update(BoardItem item)
        {
            var dataTable = Adapter.Update(item);

            //var result = new BoardItem(dataTable);

            return dataTable;
        }

        //Create ok
        public string Create(BoardItem item)
        {
            var dataTable = Adapter.Create(item);

            // dataTable -> List<BoardItem>
            var data = new List<BoardItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                data.Add(new BoardItem(row));
            }

            string json = JsonConvert.SerializeObject(data);

            return json;
        }

        public string Search(SearchCondition searchCondition)
        {
            var dataTable = Adapter.Search(searchCondition);

            // dataTable -> List<BoardItem>
            var data = new List<BoardItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                data.Add(new BoardItem(row));
            }

            string json = JsonConvert.SerializeObject(data);

            return json;
        }

        //AllDelete  ok
        public DataTable DeleteAll()
        {
            var dataTable = Adapter.DeleteAll();

            return dataTable;
        }

        //Delete ok
        public string DeleteById(string itemId)
        {
            var dataTable = Adapter.Delete(itemId);

            // dataTable -> List<BoardItem>
            var data = new List<BoardItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                data.Add(new BoardItem(row));
            }

            string json = JsonConvert.SerializeObject(data);

            return json;
        }

        //Detail  ok
        public string GetDetailById(BoardItem item)
        {
            var dataTable = Adapter.GetDataById(item);

            // dataTable -> List<BoardItem>
            var data = new List<BoardItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                data.Add(new BoardItem(row));
            }

            string json = JsonConvert.SerializeObject(data);

            return json;
        }
    }
}
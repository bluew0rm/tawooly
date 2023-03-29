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

        //SelectAll
        public DataTable GetAllData()
        {
            DataTable dataTable = Adapter.GetDataByAll();

            return dataTable;
        }

        

        //Create
        public string Create(BoardItem item)
        {
            var dataTable = Adapter.Create(item);

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

        //AllDelete
        public DataTable DeleteAll()
        {
            var dataTable = Adapter.DeleteAll();

            return dataTable;
        }

        //Delete
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

        //Update
        public DataTable Detail(string item)
        {
            var dataTable = Adapter.Detail(item);

            return dataTable;
        }

        //Update
        public string Update(BoardItem item)
        {
            var dataTable = Adapter.Update(item);

            // dataTable -> List<BoardItem>
            var data = new List<BoardItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                data.Add(new BoardItem(row));
            }

            string json = JsonConvert.SerializeObject(data);

            return json;
        }

        //Detail
        public string DetailById(BoardItem item)
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
using Newtonsoft.Json;
using Project_Board.Models;
using Project_Board.Models.Search;
using Project_Board.Service.Adepter;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.DynamicData;
using System.Web.Http.Results;
using static System.Net.Mime.MediaTypeNames;

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
        public DataTable Create(BoardItem item)
        {
            var dataTable = Adapter.Create(item);

            return dataTable;
        }

        //AllDelete  ok
        public DataTable AllDelete()
        {
            var dataTable = Adapter.AllDelete();

            return dataTable;
        }

        //Delete ok
        public DataTable GetDeleteById(string id)
        {
            var dataTable = Adapter.Delete(id);

            //var result = new BoardItem(dataTable);

            return dataTable;
        }

        //Detail  ok
        public DataTable GetDetailById(string id)
        {
            var dataTable = Adapter.GetDataById(id);

            //var result = new BoardItem(dataTable);

            return dataTable;
        }

        //Search
        /*public DataTable Search(BoardItem item)
        {
            
            var dataTable = Adapter.Search(item);

            return dataTable;
        }*/

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

        //public List<BoardItem> Search(SearchCondition searchCondition)
        //{

        //    var dataTable = Adapter.Search(searchCondition);
        //    var a = dataTable.Rows;
        //    var result = new List<BoardItem>();
        //    foreach(DataRow row in a)
        //    {
        //        result.Add(new BoardItem(row));
        //    }


        //    return result;
        //}
    }
}
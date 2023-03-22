using Project_Board.Models;
using Project_Board.Service.Adepter;
using System;
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
        public DataTable Search(BoardItem item)
        {
            
            var dataTable = Adapter.Search(item);

            return dataTable;
        }

    }
}
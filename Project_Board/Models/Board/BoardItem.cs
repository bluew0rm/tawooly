using System;
using System.Data;

namespace Project_Board.Models
{

    public class BoardItem
    {
        private int _id;
        private string _title;
        private string _text;
        private string _writer;
        private string _update;

        public BoardItem() { }
        public BoardItem(DataTable dataTable)
        { 

        }

        public BoardItem(int id, string title, string text, string writer, string update)
        {
            _id = id;
            _title = title;
            _text = text;
            _writer = writer;
            _update = update;
        }

        public BoardItem(string title, string writer, string update, string text)
        {
            _title = title;
            _text = text;
            _writer = writer;
            _update = update;
        }

        public int Id { get { return _id; } }
        public string Title { get { return _title; } }
        public string Text { get { return _text; } }
        public string Writer { get { return _writer; } }
        public string Update { get { return _update; } }
    }
}
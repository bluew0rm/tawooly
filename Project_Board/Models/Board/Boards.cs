using System;

namespace Project_Board.Models
{

    public class Boards
    {
        private int _id;
        private string _title;
        //private string _category;
        private string _text;
        private string _writer;
        private string _update;

        public Boards(int id, string title, /*string category*/ string text, string writer, string update)
        {
            _id = id;
            _title = title;
            //_category = category;
            _text = text;
            _writer = writer;
            _update = update;
        }

        public int Id { get { return _id; } }
        public string Title { get { return _title; } }
        //public string category { get { return _category; } }
        public string Text { get { return _text; } }
        public string Writer { get { return _writer; } }
        public string Update { get { return _update; } }
    }
}
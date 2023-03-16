using System.Data;
using System.Security.Cryptography;

namespace Project_Board.Models.Search
{
    public class SearchBoardItem
    {
        private string _title;

        public SearchBoardItem(string title)
        {
            _title = title;
        }

        public string Title { get { return _title; } }
    }
}
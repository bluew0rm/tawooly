using System;
using System.Data;

namespace Project_Board.Models
{

    public class BoardItem
    {

        public BoardItem() { }
        public BoardItem(DataTable dataTable)
        {

        }

        public BoardItem(int id, string title, string text, string writer, DateTime updatedDate)
        {
            Id = id;
            Title = title;
            Text = text;
            Writer = writer;
            UpdatedDate = updatedDate;
        }

        public BoardItem(string title, string text, string writer, DateTime updatedDate)
        {
            Title = title;
            Text = text;
            Writer = writer;
            UpdatedDate = updatedDate;
        }

        public BoardItem(DataRow row)
        {
            Id = int.Parse(row[0].ToString());
            Title = row[1].ToString();
            Text = row[2].ToString();
            Writer = row[3].ToString();
            UpdatedDate = DateTime.Parse(row[4].ToString());
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Writer { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
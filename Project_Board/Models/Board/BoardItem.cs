using System;
using System.Data;

namespace Project_Board.Models
{

    public class BoardItem
    {
        private DataRow row;

        public BoardItem() { }
        public BoardItem(DataTable dataTable)
        {

        }



        //"Id": id.value,
        //"Title": title.value,
        //"Writer": writer.value,
        //"FromDate": fromDate.value,
        //"ToDate": toDate

        public BoardItem(int id, string title, string writer, DateTime updatedDate, string text)
        {
            Id = id;
            Title = title;
            Text = text;
            Writer = writer;
            UpdatedDate = updatedDate;
        }

        public BoardItem(string title, string writer, DateTime updatedDate, string text)
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
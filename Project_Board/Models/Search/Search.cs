
using System;

namespace Project_Board.Models.Search
{
    public class SearchCondition
    {
        public int Id { get; set; } = 0; 
        public string Writer { get; set; }
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
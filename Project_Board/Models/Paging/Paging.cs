
namespace Project_Board.Models.Paging
{
    public class Paging
    {
        public int PageIndex { get; set; } = 0; 
        public int PageCount { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public Paging() { }
    }
}
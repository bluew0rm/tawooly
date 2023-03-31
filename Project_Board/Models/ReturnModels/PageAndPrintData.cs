
using System.Collections.Generic;

namespace Project_Board.Models.Paging
{
    public class PageAndPrintData
    {
        public List<BoardItem> PrintItem { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
        public PageAndPrintData(List<BoardItem> printItem, PagingInfo pagingInfo)
        {
            PrintItem = printItem;
            PagingInfo = pagingInfo;
        }
    }
}
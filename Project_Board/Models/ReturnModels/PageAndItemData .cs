
using Project_Board.Models.Search;
using System.Collections.Generic;

namespace Project_Board.Models.Paging
{
    public class PageAndItemData
    {
        public SearchCondition SearchItem { get; set; }
        public BoardItem Item { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
        public PageAndItemData (SearchCondition searchItem, PagingInfo pagingInfo)
        {
            SearchItem = searchItem;
            PagingInfo = pagingInfo;
        }
    }
}
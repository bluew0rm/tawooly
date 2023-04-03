
using Project_Board.Models.Search;
using System.Collections.Generic;

namespace Project_Board.Models.Paging
{
    public class PageAndItemListData
    {
        public List<BoardItem> ItemList { get; set; }
        public SearchCondition SearchItem { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
        public PageAndItemListData(List<BoardItem> items, PagingInfo pagingInfo)
        {
            ItemList = items;
            PagingInfo = pagingInfo;
        }

        public PageAndItemListData(SearchCondition searchItem, PagingInfo pagingInfo)
        {
            SearchItem = searchItem;
            PagingInfo = pagingInfo;
        }
        public PageAndItemListData() { }
    }
}
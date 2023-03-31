
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Project_Board.Models.Paging
{
    public class PagingInfo
    {
        //현재 페이지
        public int PageIndex { get; set; } = 0;
        //한 페이지 당 n개 게시글
        public int PageCount { get; set; }
        //게시글 총 갯수
        public int TotalPages { get; set; }

        //화면에 페이지이동버튼을 몇개 표시할지
        public int PageSize { get; set; }
        public PagingInfo(DataRow row)
        {
            PageIndex = int.Parse(row[0].ToString());
            PageCount = int.Parse(row[1].ToString());
            TotalPages = int.Parse(row[2].ToString());
        }

        public PagingInfo(int idx, int count, int total)
        {
            PageIndex = idx;
            PageCount = count;
            TotalPages = total;
        }

        public PagingInfo(){}
    }
}
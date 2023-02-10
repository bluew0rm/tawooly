

using System.ComponentModel.DataAnnotations;

namespace TestBoard.Models
{


    public class BoardDB
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }
        
        public string? Text { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}

/* データモデルクラスのポイント
 * 1. クラス名とテーブル名を一致させる
 * 2. 各プロパティとテーブルの列名と一致させる
 * 3. dプロパティがテーブルの主キーとなる */
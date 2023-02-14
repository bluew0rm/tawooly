

using System.ComponentModel.DataAnnotations;


namespace TestBoard.Models
{


    public class Management
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        
        public string? Gender { get; set; }

        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}

/* データモデルクラスのポイント
 * 1. クラス名とテーブル名を一致させる
 * 2. 各プロパティとテーブルの列名と一致させる
 * 3. IDプロパティがテーブルの主キーとなる */
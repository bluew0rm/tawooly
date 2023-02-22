using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SamplePage.Models
{
    public class Board
    {
        [Key]
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string KATEGORIES { get; set; }
        public string WRITER { get; set; }
    }
}
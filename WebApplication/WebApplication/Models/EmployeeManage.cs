using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EmployeeManage
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public int AGE { get; set; }
        public string GENDER { get; set; }
        public string PHONE { get; set; }
        public string ADRESS { get; set; }
    }
}


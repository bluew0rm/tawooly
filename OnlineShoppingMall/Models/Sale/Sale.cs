using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMall.Models.Sale
{
    public class Sale
    {
        private int id;
        private string name;
        private int salePercent;
        private DateTime stardDate;
        private DateTime endDate;
        private DateTime addDate;
        private string addBy;
        private string updateBy;

        public int Id { get { return id; } }
        private string Name { get { return name; } }
        private int SalePercent { get { return salePercent; } }
        private DateTime StardDate { get { return stardDate; } }
        private DateTime EndDate { get { return endDate; } }
        public DateTime AddDate { get { return addDate; } }
        public string AddBy { get { return addBy; } }
        public DateTime UpdateDate { get; } = DateTime.Now;
        public string UpdateBy { get { return updateBy; } }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMall.Models.Good
{
    public class Good
    {
        private int id;
        private string name;
        private string explanation;
        private int price;
        private int stock;
        private int categoryId;
        private int softDelete;
        private DateTime stardDate;
        private DateTime endDate;
        private DateTime addDate;
        private string addBy;
        private string updateBy;

        public int Id { get { return id; } }
        private string Name { get { return name; } }
        private string Explanation { get { return explanation; } }
        private int Price { get { return price; } }
        private int Stock { get { return stock; } }
        private int CategoryId { get { return categoryId; } }
        private int SoftDelete { get { return softDelete; } }
        public DateTime StardDate { get { return stardDate; } }
        private DateTime EndDate { get { return endDate; } }
        public DateTime AddDate { get { return addDate; } }
        public string AddBy { get { return addBy; } }
        public DateTime UpdateDate { get; } = DateTime.Now;
        public string UpdateBy { get { return updateBy; } }
    }
}
}
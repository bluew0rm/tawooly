using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMall.Models.Cart
{
    public class Cart
    {
        private int id;
        private int userAccountId;
        private int goodsId;
        private int saleId;
        private int consumptionTaxId;
        private DateTime addDate;
        private string addBy;
        private string updateBy;

        public int Id { get { return id; } }
        private int UserAccountId { get { return userAccountId; } }
        private int GoodsId { get { return goodsId; } }
        private int SaleId { get { return saleId; } }
        private int ConsumptionTaxId { get { return consumptionTaxId; } }
        public DateTime AddDate { get { return addDate; } }
        public string AddBy { get { return addBy; } }
        public DateTime UpdateDate { get; } = DateTime.Now;
        public string UpdateBy { get { return updateBy; } }
    }
}
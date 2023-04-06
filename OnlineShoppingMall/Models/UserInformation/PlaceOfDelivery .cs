using System;


namespace OnlineShoppingMall.Models.UserInformation
{
    public class PlaceOfDelivery
    {
        private int id;
        private string userId;
        private int postNumber;
        private string address;
        private DateTime addDate;
        private string addBy;
        private string updateBy;

        public int Id { get { return id; } }
        public string UserId { get { return userId; } }
        public int PostNumber { get { return postNumber; } }
        public string Address { get { return address; } }
        public DateTime AddDate { get { return addDate; } }
        public string AddBy { get { return addBy; } }
        public DateTime UpdateDate { get; } = DateTime.Now;
        public string UpdateBy { get { return updateBy; } }
    }
}
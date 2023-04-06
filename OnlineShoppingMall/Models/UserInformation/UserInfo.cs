using System;


namespace OnlineShoppingMall.Models.User
{
    public class UserInfo
    {
        private string id;
        private string name;
        private DateTime birth;
        private string gender;
        private string email;
        private string phoneNumber;
        private int postNumber;
        private string address;
        private DateTime addDate;

        public string Id { get { return id; } }
        private string Name { get { return name; } }
        private DateTime Birth { get { return birth; } }
        private string Gender { get { return gender; } }
        private string Email { get { return email; } }
        private string PhoneNumber { get { return phoneNumber; } }
        public int PostNumber { get { return postNumber; } }
        public string Address { get { return address; } }
        public DateTime AddDate { get { return addDate; } }
        public DateTime UpdateDate { get; } = DateTime.Now;
    }
}
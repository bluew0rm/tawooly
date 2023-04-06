using System;


namespace OnlineShoppingMall.Models.UserInformation
{
    public class UserAccount
    {

        private int id;
        private string userId;
        private string password;
        private DateTime addDate;
        private string addBy;
        private string updateBy;


        //get은 받는거. set은 외부에서 설정할 수 있게하는거.
        public int Id { get { return id; } }
        public string UserId { get { return userId; } }
        public string Password { get { return password; } }
        public DateTime AddDate { get { return addDate; } }
        public string AddBy { get { return addBy; } }
        public DateTime UpdateDate { get; } = DateTime.Now;
        public string UpdateBy { get { return updateBy; } }
    }
}

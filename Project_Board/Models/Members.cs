namespace Project_Board.Models
{

    public class Members
    {
        private int _id;
        private string _name;
        private int _age;
        private string _gender;
        private string _job;

        public Members(int id, string name, int age, string gender, string job)
        {
            _id = id;
            _name = name;
            _age = age;
            _gender = gender;
            _job = job;
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public int Age { get { return _age; } }
        public string Gender { get { return _gender; } }
        public string Job { get { return _job; } }
    }
}
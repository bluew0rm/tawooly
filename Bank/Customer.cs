
namespace Bank
{
    public class Customer
    {
        private int _id;
        private string _name;

        public Customer(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id { get { return _id;} }
        public string Name { get { return _name;} }

        //public override string ToString() { return _name + _id; }


    }
}

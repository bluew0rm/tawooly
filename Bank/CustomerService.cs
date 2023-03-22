
using System.Xml.Linq;

namespace Bank
{
    public class CustomerService
    {
        CustomerList customerList = new CustomerList();

        Dictionary<int, List<Customer>> customer = new Dictionary<int, List<Customer>>();

        List<Customer> customers = new List<Customer>();


        public void CustomerSet()
        {
            Customer customer1 = new Customer(11, "Tanaka");
            customers.Add(customer1);

            Customer customer2 = new Customer(22, "Sasaki");
            customers.Add(customer2);

            Customer customer3 = new Customer(33, "Kobe");
            customers.Add(customer3);

            Customer customer4 = new Customer(44, "Yashiro");
            customers.Add(customer4);

            Customer customer5 = new Customer(55, "Nakajima");
            customers.Add(customer5);

            Customer customer6 = new Customer(66, "Iwasaki");
            customers.Add(customer6);

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.Name);
            }

        }

        //顧客確認
        public void PrintAllCustomer()
        {
            for (int i = 0; i<7; i++)
            {
                customer.Add(i, customers);
            }

            foreach (var item in customer)
            {
                Console.WriteLine("御社の顧客リスト：" + item.Key + " - " + item.Value.ToList());
            }
            Console.WriteLine();
        }

        //新規登録
        /*public void AddNewCustomer(int id, string name)
        {
            Customer addCustomer = new Customer(id, name);
            customer.Add(id, addCustomer);

            Console.WriteLine("最近追加された顧客リスト：{0}-{1}", id, name);
            Console.WriteLine();

            foreach (var item in customer)
            {
                Console.WriteLine("御社の顧客リスト：" + item.Key + " - " + item.Value);
            }
            Console.WriteLine();
        }*/



        //情報確認
        public void PrintCustomerById(int id)
        {
            
            if (customer.ContainsKey(id))
            {
                Console.WriteLine("いらっしゃいませ、" + customer[id] + "様。");
            }
            else
            {
                Console.WriteLine("もう一度IDをご確認ください。");
            }
            Console.WriteLine();
        }


    }
}

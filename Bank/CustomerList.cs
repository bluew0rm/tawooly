using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bank
{
    public class CustomerList
    {

        public void CustomerSet()
        {
            List<Customer> customers = new List<Customer>();

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
        }
    }
}

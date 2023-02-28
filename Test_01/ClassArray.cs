using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_01
{
    public class ClassArray
    {
        string[] coffee = new string[]
        {
            "black",
            "coldblue",
            "latte"
        };

        public void menu()
        {
            Console.WriteLine("MENUは" + string.Join(",", coffee) + "です。");

            var aa = new ArrayList();

            aa.Add("a");
            aa.Add("b");
            aa.Add("c");
            aa.Add("c");
            aa.Add("c");
            aa.Add("c");

        }
    }
}

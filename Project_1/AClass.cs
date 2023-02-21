using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    //클래스 만들기
    public class AClass
    {
        public void aMethod(int b)
        {
            int a = 3;
            Console.WriteLine(a - b);
        }

        public void bMethod(string a, string b)
        {
            Console.WriteLine(a + b);
        }

        public void cMethod(int a, string b)
        {
            Console.WriteLine(a + b);
        }

    }
}

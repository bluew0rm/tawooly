using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    public class TestArray
    {
        int[] Num = new int[4] { 23, 43, 61, 34 };

        public void ArrayA()
        {
            Console.WriteLine(Num);
        }

        public void ArrayB(int a)
        {
            Console.WriteLine(Num[a]);
        }

        public void ArrayC()
        {
            Console.WriteLine(Num.Length);
        }
    }
}


using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Test_01
{
    public class Test_List
    {
        //①リストを生成
        List<string> elements = new List<string>();

        //②elementを100個Addする（for利用）값에 인덱스를 넣기
        public void SetElements()
        {
            for(int i = 0; i < 100; i++)
            {
                elements.Insert(i, (i+1).ToString());
                Console.WriteLine("・「element」リストの" +i +"番目の内容は、" + elements[i]);
            }
        }

        //③홀수번째 엘리먼트만 출력
        //④짝수번째 엘리먼트만 출력
        public void PrintElemets(bool isOdd)
        {
            if (isOdd)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (0 != i % 2)
                    {
                        Console.WriteLine("・Indexが偶数の要素を出力します：" + elements[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (0 == i % 2)
                    {
                        Console.WriteLine("・Indexが奇数の要素を出力します：" + elements[i]);
                    }
                }
            }
        }
        //⑤엘리먼트의 값이 X로 시작하는 엘리먼트만 출력
        public void PrintElemetsStartsWith(string x)
        {
            for (int i = 0; i < elements.Count; i++)
            {

                if (elements[i].StartsWith(x))
                {
                    Console.WriteLine("・"+ x +"で始まる要素は、：" + elements[i]);
                }
            }

        }

        public void PrintElemetsLastsWith(string x)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                var a = elements[i];

                if (a.Substring(a.Length-1,1).Equals(x))
                {
                    Console.WriteLine("・" + x + "が最後に来る要素は、：" + elements[i]);
                }
            }

        }



        //⑥홀수 번째 엘리먼트만 삭제 후 모든 엘리먼트 출력
        public void OddRemove()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements.RemoveAt(i);
                Console.WriteLine("・Indexが偶数の要素を削除します：" + elements[i]);
            }
        }

        //⑦전부 삭제 후 엘리먼트 출력
        public void ListClear()
        {
            elements.Clear();

            Console.WriteLine("・Listの内容を削除します：");
            foreach (string a in elements)
            {
                Console.WriteLine(a);
            }
        }

    }
}

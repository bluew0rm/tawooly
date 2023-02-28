
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

        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //①파더 객체가 100개 들어간 리스트 생성
        List<Father> fatherList = new List<Father>();
        public void FatherSet()
        {
            
            for (int i = 0; i < 100; i++)
            {
                var father = "father" + (i + 1);
                //インスタンスを作成
                fatherList.Add(new Father(father));

                /*var fatherName = fatherObjectList[i]._name;
                Console.WriteLine("fatherListの"+i+"番目の要素は、"+fatherName);*/
            }

            foreach (Father result in fatherList)
            {
                Console.WriteLine("fatherListの要素は「" + result._name + "」");
            }
            Console.WriteLine();
        }
        
        //②리스트에서 파더 이름에 5가 들어가는 엘리먼트 삭제
        public void PrintFatherRemouveInclude(string x)
        {
            fatherList.RemoveAll(item => item._name.Contains(x) == true);
            foreach (Father result in fatherList)
            {
                Console.WriteLine("fatherList、「5」が含まれている要素名は削除しました。「" + result._name + "」");
            }
            Console.WriteLine();
        }

        public void PrintFatherName()
        {
            foreach (Father result in fatherList)
            {
                Console.WriteLine("現在のfatherListの要素名は「" + result._name + "」です。");
            }
            Console.WriteLine();
        }
    }
}

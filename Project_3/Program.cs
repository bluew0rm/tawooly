// See https://aka.ms/new-console-template for more information

//配列要素で　初期化
using System.Reflection.Metadata;

string[] arr1 = { "a", "b", "c" };
//List　宣言
List<string> a;
//List　객체 생성
a = new List<string>(arr1);
Console.WriteLine();


//List　宣言と객체 생성(同時に)
List<string> b = new List<string>();
Console.WriteLine();


//Add( ) / 요소를 지정하며 값 넣기
b.Add("aa");
b.Add("bb");
b.Add("cc");
b.Add("dd");
b.Add("EE");
b.Add("FF");
b.Add("GG");
b.Add("hh");
b.Add("rr");
b.Add("jj");
b.Add("kk");

Console.WriteLine();


//List　宣言と객체 생성,(同時に初期化)
List<string> c = new List<string>() {"a", "b", "c"};
Console.WriteLine();
Console.WriteLine();

//---------------------------------------------------------------

//Index
Console.WriteLine("Result list b[0] : "+ b[0]);
Console.WriteLine();


//Join( )
Console.WriteLine("Result list a : " + string.Join(", ", a));
Console.WriteLine();


//Count (プロパティ)
Console.WriteLine("List Cの中には要素が " + c.Count +"個入っている。");
Console.WriteLine();


//for文
for (int i = 0;i < b.Count; i++)
{
    Console.Write("Result list b(for(" + i + ")) : ");
    Console.WriteLine( b[i]);
}
Console.WriteLine();


//foreach文
foreach (string foreachA in a)
{
    Console.WriteLine("foreach in listA : " + foreachA);
}
Console.WriteLine();


//Contains( )
Console.WriteLine("List a in [a] → " + a.Contains("a"));

if (a.Contains("a"))
{
    Console.WriteLine("List aには [a]があります。");
}else
{
    Console.WriteLine("List aには [a]がありません。");
}
Console.WriteLine();


//IndexOf( )
Console.WriteLine("List s 中 [c]は " + a.IndexOf("c") + "番目にある。");
Console.WriteLine();


//Insert( )
c.Insert(0, "z");

foreach(string foreachB in c)
{
    Console.WriteLine("List Cの要素がIndexで追加されました : " + foreachB);
}
Console.WriteLine();


//RemoveAt( )
c.RemoveAt(0);

foreach (string foreachc in c)
{
    Console.WriteLine("List Cの要素がIndexで削除されました : " + foreachc);
}
Console.WriteLine();


//Remove( )
c.Remove("c");

foreach (string foreachc in c)
{
    Console.WriteLine("List Cの要素が直接削除されました : " + foreachc);
}
Console.WriteLine();


//RemoveRange()
b.RemoveRange(4,6);

foreach (string foreachd in b)
{
    Console.WriteLine("List Bの大文字だった範囲が削除されました : " + foreachd);
}
Console.WriteLine();


//Clear()
c.Clear();

foreach (string foreache in c)
{
    Console.WriteLine("List Cは削除されました : " + foreache);
}
Console.WriteLine();


//Reverse( )
b.Reverse();
foreach (string foreachf in b)
{
    Console.WriteLine("List Bを逆から出力します : " + foreachf);
}
Console.WriteLine();



//------------------------------------------------------------

//更新
b[0] = "ee";
foreach (string foreachf in b)
{
    Console.WriteLine("List Bの要素を更新します : " + foreachf);
}
Console.WriteLine();


//List 안에 List
c.Add("a");
c.Add("b");
c.Add("c");
c.Add("d");
c.Add("e");

var list1 = new List<List<string>>();

list1.Add(b);
list1.Add(c);

Console.WriteLine("Listの中にListを入れる。");
Console.Write(list1[0][0] + " | ");
Console.Write(list1[0][1] + " | ");
Console.Write(list1[0][2] + " | ");
Console.Write(list1[0][3] + " | ");
Console.WriteLine(list1[0][4]);
Console.WriteLine("-----------------------");
Console.Write(list1[1][0] + "  | ");
Console.Write(list1[1][1] + "  | ");
Console.Write(list1[1][2] + "  | ");
Console.Write(list1[1][3] + "  | ");
Console.WriteLine(list1[1][4]);
Console.WriteLine();


//메소드의 파라미터와 리턴값이 List
List<string> aaa = cba(b);

foreach (string list4 in aaa)
{
    Console.WriteLine("List Bが出力されます : " + list4);
}

List<string> cba(List<string> abc)
{
    return abc;
}
Console.WriteLine();

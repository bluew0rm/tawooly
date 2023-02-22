// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var animal = new Dictionary<string, string > ();

animal.Add("A","dog");
animal.Add("B", "cat");

//------------------------------------------------------------------------

foreach (KeyValuePair<string, string>  item in animal)
{
    Console.WriteLine("キーと値、すべて出力 : " + "[{0}:{1}]", item.Key, item.Value);
}

Console.WriteLine();


foreach (string key1 in animal.Keys)
{
    Console.WriteLine("キーだけ出力 : " + key1);
}

Console.WriteLine();


foreach (string value1 in animal.Values)
{
    Console.WriteLine("値だけ出力 : " + value1);
}

Console.WriteLine();


string value2 = "B";
Console.WriteLine("キーで値を見つける : " + "キーは " + value2 + "で、その値は" + animal[value2] + "です。");

Console.WriteLine();



if (animal.ContainsKey(value2))
{
    Console.WriteLine("{0}はすでに使われています。", value2);
}else
{
    Console.WriteLine("{0}を使用しても構いません。", value2);
}
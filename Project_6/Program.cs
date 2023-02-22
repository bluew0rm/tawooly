// See https://aka.ms/new-console-template for more information
using Project_6;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");


HashSet<Animal> animals = new HashSet<Animal>()
{
    new Animal{type="dog1", name="Adog"},
    new Animal{type="dog2", name="Bdog"},
    new Animal{type="cat1", name="Ccar"},
    new Animal{type="cat2", name="Dcat"},
    new Animal{type="duck1", name="Educk"},
    new Animal{type="duck2", name="Fduck"}
};

//Hashを巡回できる열거자
HashSet<Animal>.Enumerator em = animals.GetEnumerator();

            //hashsetの中にある次の要素に移動。最後の要素を過ぎるとfalse
while(em.MoveNext())
{                      //現在値を出力
    Animal an = em.Current;
    Console.WriteLine("種類は{0}で、名前は{1}です。", an.type , an.name);
}



HashSet<int> num = new HashSet<int>()
{
    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
};

int a = 0;
Console.WriteLine("「10」は存在するのか → " + num.TryGetValue(10,out a) + " → " + a);


int b = 0;
Console.WriteLine("「20」は存在するのか → " + num.TryGetValue(20, out b) + " → " + b);


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

HashSet<employee> numbers = new HashSet<employee>()
{
    new employee{name="chung", age=20,birth=1018},
    new employee{name="song",  age=30,birth=1202},
    new employee{name="jyan",  age=40,birth=0329},
    new employee{name="kim",   age=50,birth=1120},
    new employee{name="kang",  age=60,birth=0501},
};

//前
foreach(employee items in numbers)
{
    Console.WriteLine("名前：{0} / 年齢：{1} / 誕生日：{2}",items.name,items.age,items.birth);
}

Console.WriteLine();
Console.WriteLine("削除中です。");
Console.WriteLine(numbers.RemoveWhere(item => item.age > 40)+"個のデータを削除します。");
Console.WriteLine();

//後
foreach (employee items in numbers)
{
    Console.WriteLine("名前：{0} / 年齢：{1} / 誕生日：{2}", items.name, items.age, items.birth);
}
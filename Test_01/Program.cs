// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Reflection.Emit;
using Test_01;


/*
//①enum 정의, 생성
Week week;

week = Week.Friday;

Console.WriteLine(week);


Console.WriteLine();
//②string의 array 생성, 추가, 삭제, 전부 삭제
string[] employee = new string[5];

employee[0] = "ID";
employee[1] = "NAME";
employee[2] = "AGE";
employee[3] = "GENDER";






Console.WriteLine();
//②class를 정의, class의 array 생성, 추가, 삭제, 전부 삭제
ClassArray coffee = new ClassArray();
coffee.menu();


Console.WriteLine();
//③string의 arrayList 생성, 추가, 삭제, 전부 삭제



//③class를 정의, class의 arrayList 생성, 추가, 삭제, 전부 삭제



Console.WriteLine();
//④string의 list 생성, 추가, 삭제, 전부 삭제
List<string> animal = new List<string>();


*//*"dog",
"cat"
};*//*
animal.Add(employee[0]);
animal.AddRange(employee);
animal.Remove(employee[1]);
animal.RemoveRange(0, 1);
animal.RemoveAt(0);

animal.Clear();




Console.WriteLine("Listの内容：" + string.Join(",", animal));

animal.Add("rabbit");
animal.Add("duck");
Console.WriteLine("rabbitとduckを追加：" + string.Join(",", animal));

animal.Remove("dog");
Console.WriteLine("dogを削除：" + string.Join(",", animal));

animal.Clear();
Console.WriteLine("全削除：" + string.Join(",", animal));
Console.WriteLine();



//④class를 정의, class의 list 생성, 추가, 삭제, 전부 삭제

ClassList people = new ClassList();

people.People(0);
Console.WriteLine();


*//*var myList = new List<Father>();

var f1 = new Father();
myList.Add(f1);
var f2 = new Father();

myList.Add(f2);*//*


//⑤string의 dictionary 생성, 추가, 삭제, 전부 삭제
Dictionary<string, string> book = new Dictionary<string, string>();

book.Add("Aさん", "aaa");
book.Add("Bさん", "bbb");
book.Add("Cさん", "ccc");
book.Add("Dさん", "ddd");

book.Remove("Aさん");

var a = book.Keys;

Console.WriteLine("Aさんを削除します。：" + string.Join(",", book));
Console.WriteLine("Aさんを削除します。：" + string.Join(",", book.Keys));
Console.WriteLine("Aさんを削除します。：" + string.Join(",", book.Values));

var b = book.Select(x => x.Key).ToList();





//⑤class를 정의, class의 dictionary 생성, 추가, 삭제, 전부 삭제


//⑥string의 hashset 생성, 추가, 삭제, 전부 삭제
HashSet<string> world = new HashSet<string>();

world.Add("China");

world.Remove("China");
world.Clear();

Console.WriteLine(string.Join(",", world));


//⑥class를 정의, class의 hashset 생성, 추가, 삭제, 전부 삭제

*/


//--------------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------------

//①リストを生成
Test_List element = new Test_List();

//②elementを100個Addする（for利用）값에 인덱스를 넣기(삭제해도 원래 인덱스가 뭐였는지 알수 있으니까)
element.SetElements();
Console.WriteLine();

//③홀수번째 엘리먼트만 출력
element.PrintElemets(true);
Console.WriteLine();

//④짝수번째 엘리먼트만 출력
element.PrintElemets(false);
Console.WriteLine();

//⑤엘리먼트의 값이 1로 시작하는 엘리먼트만 출력
element.PrintElemetsStartsWith("1");
Console.WriteLine();


element.PrintElemetsLastsWith("1");
Console.WriteLine();


//⑥홀수 번째 엘리먼트만 삭제 후 모든 엘리먼트 출력
element.OddRemove();
Console.WriteLine();

//⑦전부 삭제 후 엘리먼트 출력
element.ListClear();

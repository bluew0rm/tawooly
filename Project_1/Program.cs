// See https://aka.ms/new-console-template for more information
using Project_1;
using System.Formats.Asn1;

Console.WriteLine("Hello, World!");


//변수 선언
int a;

//초기화
int b = 1;
a = 0;
Console.WriteLine(a);

//변수에 값 할당
a = 1;
Console.WriteLine(a);


Console.WriteLine(b);

// --------------------------------------------------------------------------------------------------------------------------------------------


//클래스의 객체 만들기
var aClass = new AClass();

//클래스 메소드(함수) 호출하기
aClass.aMethod(9);
aClass.bMethod("Strwoberry", "Gem");
aClass.cMethod(3, " Three");

// --------------------------------------------------------------------------------------------------------------------------------------------

//상속받기
var bClass = new BClass();
bClass.aMethod(3);

// --------------------------------------------------------------------------------------------------------------------------------------------

//다른 클래스에서 메서드 호출
var dclass = new DClass();
dclass.d();

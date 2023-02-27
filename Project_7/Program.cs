// See https://aka.ms/new-console-template for more information
using static Project_7.Programs;

Console.WriteLine("Hello, World!");

Week week = Week.Friday;

switch(week)
{
    case Week.Saturday:
        Console.WriteLine("土曜日だね！");
        break;

    case Week.Sunday:
        Console.WriteLine("日曜日だね！");
        break;

    case Week.Friday:
        Console.WriteLine("金曜日だね！");
        break;
}

//intにキャスティング
Week weeks;

weeks = Week.Monday;

Week weekss = Week.Sunday;

int weekly = (int)weeks;
int weeklyy = (int)weekss;
Console.WriteLine(weeks + "をint typeに変換すると、" + weekly + "になります。");
Console.WriteLine(weekss + "をint typeに変換すると、" + weeklyy + "になります。");

// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
Console.WriteLine("start main");
DoSomeThing();

Console.WriteLine("fish main");

Console.WriteLine("Hello, World!");

void DoSomeThing()
{
    Console.WriteLine("start do some thing");
 var t=  AtomicTaskAsync();
   int i = t.Result;
    Console.WriteLine("finish do something");
}

async Task<int> AtomicTaskAsync()
{
  await  Task.Delay(10000);
    return 2;
}
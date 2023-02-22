// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();  
stopwatch.Start();
Console.WriteLine("main started");
try
{
    Parallel.Invoke(Method1, Method2, Method3);
}
catch (Exception exception)
{

    Console.WriteLine(exception.Message); 
}

//Method1();
//Method2();
//Method3();


Console.WriteLine("main ended");
stopwatch.Stop();
Console.WriteLine($"Parallel Execution Took {stopwatch.ElapsedMilliseconds} Milliseconds");
Console.WriteLine("Hello, World!");



static void Method1()
{
    Thread.Sleep(200);
    Console.WriteLine($"Method 1 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
}
static void Method2()
{
    Thread.Sleep(200);
    Console.WriteLine($"Method 2 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    throw new Exception("test from invok method");
}
static void Method3()
{
    Thread.Sleep(200);
    Console.WriteLine($"Method 3 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
}
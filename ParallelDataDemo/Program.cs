// See https://aka.ms/new-console-template for more information


using System.Runtime.CompilerServices;

Console.WriteLine("main thread started");
var principalThread = Thread.CurrentThread;
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"count {i} thread Nbr: "+principalThread.ManagedThreadId);
    Thread.Sleep(50);
}

Console.WriteLine("paralell foreach loop");

var parallelOption = new ParallelOptions();
parallelOption.MaxDegreeOfParallelism= 2;



Parallel.For(1, 11, parallelOption, (i,state) => {

    Console.WriteLine($"count {i} thread Nbr: " + Thread.CurrentThread.ManagedThreadId);
    Thread.Sleep(50);
    if(i==7)
    state.Stop();
});


Console.WriteLine("Hello, World!");


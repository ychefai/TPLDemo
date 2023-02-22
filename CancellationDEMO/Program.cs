﻿// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

SomeMethod();
Console.WriteLine("Hello, World!");

Thread.Sleep(30000);
 static async void SomeMethod()
{
    int count = 10;
    Console.WriteLine("SomeMethod Method Started");
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(5000);
    //cancellationTokenSource.CancelAfter(5000);
    try
    {
        await LongRunningTask(count, cancellationTokenSource.Token);
    }
    catch (TaskCanceledException ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
    Console.WriteLine("\nSomeMethod Method Completed");
}
 static async Task LongRunningTask(int count, CancellationToken token)
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    Console.WriteLine("\nLongRunningTask Started");
    for (int i = 1; i <= count; i++)
    {
        await Task.Delay(1000);
        Console.WriteLine("LongRunningTask Processing....");
        if (token.IsCancellationRequested)
        {
            throw new TaskCanceledException();
        }
    }
    stopwatch.Stop();
    Console.WriteLine($"LongRunningTask Took {stopwatch.ElapsedMilliseconds / 1000.0} Seconds for Processing");
}
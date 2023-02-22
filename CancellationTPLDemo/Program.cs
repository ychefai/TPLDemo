// See https://aka.ms/new-console-template for more information

Console.WriteLine("main method started");
 SomeMethod();

Console.WriteLine("main method finished");
Console.WriteLine("Hello, World!");
Thread.Sleep(30000);


async void SomeMethod()
{
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
	try
	{
		Console.WriteLine("somemethod");
		cancellationTokenSource.CancelAfter(500);

		await longMethodAsync(cancellationTokenSource.Token);

		Console.WriteLine("somemethod finished");

	}
	catch (Exception exception)
	{

		Console.WriteLine(exception.Message);
	}
}

async Task longMethodAsync(CancellationToken token)
{
	Console.WriteLine("long method started");
   
    await Task.Delay(10000);

    if (token.IsCancellationRequested)
    {
        throw new TaskCanceledException();
    }
    Console.WriteLine("long method finished");
}
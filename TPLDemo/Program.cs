// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

var task = Task.Factory.StartNew(DispalMsg);
var t1 = Task.Run(() =>{Console.WriteLine("creation the run from lambda expretion");});
var t2 = new Task(DispalMsg); t2.Start();
Task<int> tIntegre = Task.Run(()=>GetSum(2,1));
var t4 = tIntegre.ContinueWith((i)=> DispalMsgString(i.ToString()));

tIntegre.ContinueWith((i) => DispalMsgString(i.ToString()),
    TaskContinuationOptions.OnlyOnFaulted);



Stopwatch stopwatch= Stopwatch.StartNew();  
stopwatch.Start();
Console.WriteLine($"Main Thread Started");
List<CreditCard> creditCards = CreditCard.GenerateCreditCards(100000);
Console.WriteLine($"Credit Card Generated : {creditCards.Count}");
ProcessCreditCards(creditCards);
Console.WriteLine($"Main Thread Completed");
stopwatch.Stop();
Console.WriteLine($"Main Thread Execution Time {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
Console.ReadKey();

Console.WriteLine("Hello, World!");


/*void display() {  }
void display(int a) {  }
float display(double a) {  }
float display(int a, float b) { }
*/

int GetSum(int a, int b) {
    return a +b;
}
void DispalMsg()
{
    Console.WriteLine("factory task method ");
}
void DispalMsgString(string msg) {
    Console.WriteLine("factory task method "+msg);
}

static async Task ProcessCreditCards(List<CreditCard> cards) { 
    Stopwatch stopwatch= new Stopwatch();
    stopwatch.Start();

    List<Task<string>> tasks = new List<Task<string>>();
    await Task.Run(()=>
    {
        foreach (var creditCard in cards)
        {
            tasks.Add(ProcessCreditCard(creditCard));
        }
    });
    await Task.WhenAll(tasks);
    stopwatch.Stop();
    Console.WriteLine($"Processing of {cards.Count} Credit Cards Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");

}

 static async Task<string> ProcessCreditCard(CreditCard creditCard) { 

    await Task.Delay(1000);
  //  Console.WriteLine("");
    string message = $"Credit Card Number: {creditCard.CardNumber} Name: {creditCard.Name} Processed";
  //Console.WriteLine($"Credit Card Number: {creditCard.CardNumber} Processed");
    return message;
}

public class CreditCard
{
    public string CardNumber { get; set; }
    public string Name { get; set; }

    public static List<CreditCard> GenerateCreditCards(int number)
    {
        List<CreditCard> creditCards = new List<CreditCard>();
        for (int i = 0; i < number; i++)
        {
            CreditCard card = new CreditCard()
            {
                CardNumber = "10000000" + i,
                Name = "CreditCard-" + i
            };

            creditCards.Add(card);
        }

        return creditCards;
    }
}
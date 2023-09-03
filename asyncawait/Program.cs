using System.Threading;
using System.Threading.Tasks;

Task task;
var tokenSource = new CancellationTokenSource();

task = Task
  .Factory
  .StartNew(DoStuff, tokenSource.Token)
  .ContinueWith(_ => task = null);

System.Console.WriteLine("Continuing sync execution");
Thread.Sleep(2000);
System.Console.WriteLine("Cancelling task");
tokenSource.Cancel();
System.Console.WriteLine("Task cancelled");

var x = Console.ReadLine();


void DoStuff()
{
  var maxLimit = 10;
  var i = 0;
  while(i < maxLimit)
  {
    if(!tokenSource.IsCancellationRequested)
    {
      System.Console.WriteLine("Sleeping for 1 secs");
      Thread.Sleep(1000);
      System.Console.WriteLine("Waking up!");
      i++;
    }
    else
    {
      System.Console.WriteLine("Task has been cancelled, exiting...");
      break;
    }
  }
}

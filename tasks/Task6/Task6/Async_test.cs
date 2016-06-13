using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Net;

namespace Task6
{
    public static class TasksExample
        {

        public static async void Run()
        {
            // test 1 : Starten eines Background Tasks
            Console.WriteLine("Shows use of Start to start on a background thread:");
            var test = Observable.Start(() =>
            {
                //This starts on a background thread.
                Console.WriteLine("From background thread. Does not block main thread.");
                Console.WriteLine("Calculating...");
                Console.WriteLine("Executing Thread: {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine("Background work completed.");
            }).Finally(() => Console.WriteLine("Main thread completed."));

            // test 2
            // CombineLatest - Parallel Execution
            //
            //Merges the specified observable sequences into one observable sequence by emitting a list with the latest source elements whenever any of the observable sequences produces an element.Console.WriteLine("\r\n\t In Main Thread...\r\n");
            var o = Observable.CombineLatest(
                Observable.Start(() => { Console.WriteLine("Executing 1st on Thread: {0}", Thread.CurrentThread.ManagedThreadId); return "Result A"; }),
                Observable.Start(() => { Console.WriteLine("Executing 2nd on Thread: {0}", Thread.CurrentThread.ManagedThreadId); return "Result B"; }),
                Observable.Start(() => { Console.WriteLine("Executing 3rd on Thread: {0}", Thread.CurrentThread.ManagedThreadId); return "Result C"; })
            ).Finally(() => Console.WriteLine("Done!"));

            foreach (string r in await o.FirstAsync())
                Console.WriteLine(r); // Result wird geschrieben

            // test 3
            // Warten bis Tastendruck erfolgt ist
            //
            Console.WriteLine("Numbers * 2: ");

            var oneNumberPerSecond = Observable.Interval(TimeSpan.FromSeconds(1));
            var numbersTimesTwo    = from n in oneNumberPerSecond
                                     select n * 2;
            numbersTimesTwo.Subscribe(num => Console.WriteLine("Numbers {0} : (after {1} sec)", num, num / 2));
           
            // Warten bis 3 Sekunden abgelaufen sind 
            test.Wait();
           
            // Danach wird erst der 
            var url = string.Format(@"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv","EURUSD");

            // Früher .... 
            var data = new WebClient().DownloadString(url);
            Console.WriteLine(data);

            // Funktioniert nicht da string nicht auf System.url umgeladen werden kann 
            //string data = await new WebClient().DownloadStringAsync(url);
            //Console.WriteLine(data);

            //Task<string> futureData = new WebClient().DownloadStringAsync(url);
            //futureData.ContinueWith(t => Console.WriteLine(t.Result));

            // Hier wird auf einen Tastendruck gewartet .. Im Hintergrund laufen die Tasks ... 
            Console.ReadKey();
         

        }

    }

       
}

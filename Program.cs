using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
         
            //===== basic tpl =======
           var basicTpl =  new BasicTPLTasks();
            
           // basicTpl.DoBasicTplTasks();
            basicTpl.DoTimedoutTplTasks();

            Console.WriteLine("======= END =======");
            Console.ReadKey();
        }

        



        static async Task DoSomethingNiceWillYea()
        {

            var val = 9;


            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            Console.WriteLine(val.ToString());

            val *= 3;

            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);



          Console.WriteLine(val.ToString());

        }
    }


    public class BasicTPLTasks
    {
        public void DoBasicTplTasks()
        {

            var t1 = new Task(
             () =>
             {
                 Console.WriteLine("t1 starting..");
                 Thread.Sleep(2000);
                 Console.WriteLine("t1 finished..");
             }
             );

            var t2 = new Task(
             () =>
             {
                 Console.WriteLine("t2 starting..");
                 Thread.Sleep(3000);
                 Console.WriteLine("t2 finished..");
             }
             );


            t1.Start();
            t2.Start();


            t1.Wait();
            t2.Wait();



        }

        public void DoTimedoutTplTasks()
        {

            var t1 = new Task(
           () =>
           {
               Console.WriteLine("t1 starting..");
               Thread.Sleep(1000);
               Console.WriteLine("t1 finished..");
           }
           );

            var t2 = new Task(
             () =>
             {
                 Console.WriteLine("t2 starting..");
                 Thread.Sleep(3000);
                 Console.WriteLine("t2 finished..");
             }
             );


            t1.Start();
            t2.Start();


           bool hasNotTimedout1 =  t1.Wait(1000);
           bool hasNotTimedout2 = t2.Wait(500);

           if (!hasNotTimedout1)
                Console.WriteLine("task 1 timeout!");

           if (!hasNotTimedout2)
                Console.WriteLine("task 2 timeout!");



        }


    }

}

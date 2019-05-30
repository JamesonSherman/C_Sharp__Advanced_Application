using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace threading
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            This file is broken into commentable sections because I honestly didnt want to handle
            multi fileable threads. Each section is broken into commented sections seperated by big lines

             */

            //____________________________________________________


             /*
             //simple thread syntax
            Console.WriteLine("Hello World! 1");
            Thread.Sleep(1000); //suspends thread for specifc ms amount
            //stops main thread be wary

            
           
            new Thread(()=>{

            }).Start(); //is the syntax to start and opena  new thread
            

            new Thread(() => {
                Thread.Sleep(1000);
                System.Console.WriteLine("Thread one");
            }).Start();
             */
            //____________________________________________________

            /* 
            //thread usage with primary success or failure checks
               //a second way to handle threading
               //seting a task completion source allows us to boolean monitor our threads
            var taskCompletionSource = new TaskCompletionSource<bool>();

            var thread = new Thread(() => 
            {
                //we can check thread placement with management thread ID

                System.Console.WriteLine($"Thread number:{Thread.CurrentThread.ManagedThreadId} started"); 
                Thread.Sleep(1000);

                //trySetResule checks our taskCompletionSource as true if it hits this peram
                //can also be set to false

                taskCompletionSource.TrySetResult(true);
               System.Console.WriteLine($"Thread number:{Thread.CurrentThread.ManagedThreadId} ended "); 
            });

            //begins thread start
            //weird note: threads need var avalible as its similar to auto data typing
            //WHO KNEW *shocked pikachu meme*

            thread.Start();

            //task completion values are assignable and are easily set to var as well

            var test = taskCompletionSource.Task.Result;
            Console.WriteLine("task was done: {0}", test);
            */

            //____________________________________________________
            //uses system.link;
            //this allows us to have an iterative range of threads

            //but have a worker handle our pool size so we dont run out of precious precious
            //THREAD
            /* 
            Enumerable.Range(0,100).ToList().ForEach(f =>
            {
                //manages the amount of threads avalible in the pool instead of raw opening threads
                ThreadPool.QueueUserWorkItem((o)=>{
               

                System.Console.WriteLine($"Thread number:{Thread.CurrentThread.ManagedThreadId} started"); 
                Thread.Sleep(1000);

               System.Console.WriteLine($"Thread number:{Thread.CurrentThread.ManagedThreadId} ended "); 
                });
            
            });

            //cool unique entry that runs this specifc thread in the background of the main
            //execution context. if main thread finishes the background thread is deleted and
            //terminated
            new Thread(() =>{
                Thread.Sleep(1000);
                Console.WriteLine("Thread 4");
            })
            {IsBackground = true}.Start();

            */
            
            //____________________________________________________



            System.Console.WriteLine("Main Thread Started");
            Thread thread1 = new Thread(Thread1Function);
            Thread thread2 = new Thread(Thread2Function);

            thread1.Start();
            thread2.Start();
            //thread blocks the main thread until the other thread ends
            thread1.Join();
            System.Console.WriteLine("thread1 function done");
            
            
        // we can check thread timesouts via ms timer and .Join(number of ms)
            if(thread2.Join(1000))
            {
                Console.WriteLine("Thread1 done");
            } 
            else
            {
                System.Console.WriteLine("thread2 did not finish in 1");
            }
            //these handy dandy join statements allow us to block threads
            //until we can join secondary thread work back
                thread2.Join();
            
            for(sbyte i = 0; i <10; i++)
            {
                 if(thread2.IsAlive)
            {
                System.Console.WriteLine("we still doing stuff in thread 2");
            }
            else
            {
                System.Console.WriteLine("we finished thread work");
            }
            }
            System.Console.WriteLine("Thread2 function done");
            System.Console.WriteLine("Main thread ended");


        }


        public static void Thread1Function()
        {
            System.Console.WriteLine("Thread1Function started");
        }

        public static void Thread2Function()
        {
            Thread.Sleep(3000);
            System.Console.WriteLine("Thread2Function started");
        }
    }
}

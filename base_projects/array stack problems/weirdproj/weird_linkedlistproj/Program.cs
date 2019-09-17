using System;

namespace weird_linkedlistproj
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //simple driver
            LinkListStack lls = new LinkListStack();
            //test for push pop scan methods.
            lls.Push(1);
            lls.Push(2);
            lls.Push(3);
            lls.Push(4);
            lls.Push(5);
            Console.WriteLine("");
            Console.WriteLine("prepop scan");
            lls.scan();
            lls.CurrentTop();
            Console.WriteLine("");
            lls.Pop();
            lls.Pop();
            lls.Pop();
            Console.WriteLine("");
            lls.CurrentTop();

            Console.WriteLine("");
           
            lls.Push(3);
            lls.Push(4);
            
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Post pop scan");
            lls.CurrentTop();
            //current stack prints from recent to first since its well... a stack.
            lls.scan();
            Console.WriteLine("finishes first part");


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            //start of driver for 2
            Console.WriteLine("starting problem 2...");
            LinkListStack lls2 = new LinkListStack();

            lls2.bottomtoendpush(1);
            lls2.bottomtoendpush(2);
            lls2.bottomtoendpush(3);
            lls2.bottomtoendpush(4);
            lls2.bottomtoendpush(5);
            lls2.scan();
            


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            //driver for 3
            Console.WriteLine("start of problem 3...");
            LinkListStack lls3 = new LinkListStack();

            lls3.topToBottom(1);
            lls3.topToBottom(2);
            lls3.topToBottom(3);
            lls3.topToBottom(4);
            lls3.topToBottom(5);
            lls3.scan();


            //unsure of the context of problem 4 but it seems the same as one. If you need help just ask.
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambdas
{
    /*
    A lambda expression is a block of code (an expression or a statement block)
    that is treated as an object. It can be passed as an argument to methods, 
    and it can also be returned by method calls. Lambda expressions are used extensively for:

    Passing the code that is to be executed to asynchronous methods, such as Task.Run(Action).

    Writing LINQ query expressions.

    Creating Expression trees

     */
    class Program
    {
        //defining a delegate allows us to run methods as objects but requires us to use
        //same perameter typing
        public delegate int SomeMath(int i);
        public delegate bool Compare(int i, Number n);
        static void Main(string[] args)
        {
           DoSomething();
           Console.ReadLine();
        }

        public static void DoSomething()
        {
            SomeMath math = new SomeMath(Square);
            Console.WriteLine(math(8));

            //inline delegation allows us to simalarly do javascripts
            //on the fly prototypal manipulation functions for specifc abstract data types and sets
            //examples are like array.filter() in js. really cool interesting system
            //using lambdas

            List<int> list = new List<int> {1,2,3,4,5,6,7};
            List<int> evenNumbers = list.FindAll(delegate (int i)
            {
                return (i % 2 == 0);
            });

            foreach (int even in evenNumbers)
            {
                System.Console.WriteLine(even);
            }

            System.Console.WriteLine("-----------------");
            List<int> oddNumbers = list.FindAll(delegate (int i)
            {
                return (i % 2 == 1);
            });

            //smaller find all
            // List<int> oddnumbs = list.FindAll(i => i%2 ==1);
            //oddNumbers.ForEach(i => Console.WriteLine(i));

            //lambda expression
            //perameters => expression/statment block

            //this can be expanded upon like so 
            //oddNumbers.forEach(i => {
            //  Console.WriteLine("Odd values");
            //  Console.WriteLine(i);
            // });
            //similar to ES 16 arrow functions and IIFE'S

            foreach(int key in oddNumbers)
            {
                System.Console.WriteLine(key);
            }

            math = new SomeMath(x => x*x*x);
            Console.WriteLine(math(8));

            //lambda expression that compstrd an integer and a number adt
            // decleration   perams    arrow function a == || != number.n  (n is the attached peram value);
            Compare comp = (a, number) => a == number.n;
        }

        public static int add(int a, int b)
        {
            return a + b;
        }

        public static int Square(int i)
        {
            return i * i;
        }

        public static int TimeTen(int i)
        {
            return i * 10;
        }
    }

    public class Number
    {
        public int n {get; set;}
    }
}

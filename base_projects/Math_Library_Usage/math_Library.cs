using System;

namespace mathy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ceiling: " + Math.Ceiling(15.3));
            Console.WriteLine("floor: " + Math.Floor(15.3));

            int num1 = 13;
            int num2 = 9;

            Console.WriteLine("Lower of num1 {0} and num2 {1} is {2}", num1, num2, Math.Min(num1, num2));
             Console.WriteLine("max of num1 {0} and num2 {1} is {2}", num1, num2, Math.Max(num1, num2));

             Console.WriteLine("3 to the power of 5 is {0}", Math.Pow(3,5));
             System.Console.WriteLine("pi is {0}", Math.PI);

             System.Console.WriteLine("the square root of 25 is {0}", Math.Sqrt(25));

             System.Console.WriteLine("always positive is {0}", Math.Abs(-25));

             System.Console.WriteLine("cos of 1 is {0}", Math.Cos(1));

             Random dice = new Random();
             int numEyes;

             for(int i=0; i <10; i++)
             {
                 //can take a min max or combination of both
                 numEyes = dice.Next(1,7);
                 System.Console.WriteLine(numEyes);
             }

                //random byte generator
                Random rnd = new Random();
                 Byte[] b = new Byte[10];
                rnd.NextBytes(b);
                Console.WriteLine("The Random bytes are: ");
                for (int i = 0; i <= b.GetUpperBound(0); i++) 
                Console.WriteLine("{0}: {1}", i, b[i]);  

        }
    }
}

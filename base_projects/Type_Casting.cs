using System;

namespace typecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            //explicit type coversion
            double myDouble = 13.37;
            int myInt;


            myInt = (Int16)myDouble;
            Console.WriteLine(myInt);
            //----------------

            //implicit conversion
            int num = 123456789;
            long bigNum = num;


            float myFloat= 13.37f;
            double myNewDouble = myFloat;

            Console.WriteLine(myNewDouble);
            //-----------------
            // pure type conversion 
            string myString = myDouble.ToString();
            Console.WriteLine(myString);
            //works with most data types for ToString(); including bool

            //parse string to int
            string numericString = "15";
            string secondString = "13";
            int num1 = Int32.Parse(numericString);
            int num2 = Int32.Parse(secondString);
            int result = num1 + num2;
            Console.WriteLine(result);

            //final note const and static values work identically to c++ and other languages so yeah
            //not going to add notes as static and const have same def's as always.
        }
    }
}

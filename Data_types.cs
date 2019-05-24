using System;

namespace data_types {
  public class Lecture {

      //static for larger public class use. helps on compilation.
       static int age = 15; //int stores - 2.147 billion to 2.147 billion
       //32 bit value
       static sbyte x = 120; //values from -128 to 127 short byte
       static short y = 30000; //stores value of -32767 to 32767

       static long zed = 900000000000; //stores up to 9 quintillion worth of positive negative values

       static float alpha = 99.99f;
        // allows decimal range from 1.5 x 10^-45 to 3.4 x ^38 (seven digit precision)

       static double beta = 3D; //up to 15 digit precision

       static decimal charlie = 1.5m; // up to 28 digit precision

       static bool torf = true;
       //t or f

       char singleLetter = 'a'; // allows single char literal or unicode

       string username = "jason1995"; //allows multiple letters and unicodes

       public static void Main(string[] args) {
           int num1 = 13;

            Console.WriteLine("sum of" + num1);
        }
    }
}

using System;

namespace string_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "AlphaBetaCharlie 1234";

            Console.WriteLine(name);

            string name2 = name.ToUpper();
            Console.WriteLine(name2);

            string name3 = name2.ToLower();
            Console.WriteLine(name3);


            //things like substring systems as well as string.format exist as well.
            string sentence = "This sentence has five words.";
            // Extract the second word.
            int startPosition = sentence.IndexOf(" ") + 1;
            
            string word2 = sentence.Substring(startPosition,
                sentence.IndexOf(" ", startPosition) - startPosition);
            
            Console.WriteLine("Second word: " + word2);


            DateTime dateAndTime = new DateTime(2011, 7, 6, 7, 32, 0);
            double temperature = 68.3;
            string result = String.Format("At {0:t} on {0:D}, the temperature was {1:F1} degrees Fahrenheit.",
            dateAndTime, temperature);

            Console.WriteLine(result);
        }
    }
}

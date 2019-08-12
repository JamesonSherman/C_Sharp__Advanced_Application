using System;

namespace BIG_0_examples_for_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void ArrayTimeComplexity(Object[] array)
        {
            //access by index o(1)
            Console.WriteLine(array[0]);

            int length = array.Length;
            object elementToFind = new object();

            //search for eleement takes O(N)
            for (int i = 0; i < length; i++)
            {
                if(array[i] == elementToFind)
                {
                    Console.WriteLine("Item found");
                }
            }

            //add to a full array
            var bigArray = new int[length * 2];
            //peram 1: source, peram 2: destination, peram 3: elements to copy
            Array.Copy(array, bigArray, length);
            bigArray[length + 1] = 10;

            //add to the end when there is some space
            array[length - 1] = 10;
        }

        private static void IterateOver(int[] array)
        {

        }
    }
}

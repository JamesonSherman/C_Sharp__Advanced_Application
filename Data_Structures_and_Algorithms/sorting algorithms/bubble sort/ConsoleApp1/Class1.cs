using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Class1
    {

        public static void BubbleSort(int[] array)
        {
            //part index is created at end of array
            //as long as the value is greater than 0 we will iterate over to the smaller
            //element
            for(int partIndex = array.Length-1; partIndex > 0; partIndex--)
            {
                for(int i = 0; i <partIndex; i++)
                {
                    if(array[i] > array[i+1])
                    {

                        //if i is less than the current partiton index value we
                        //keep calling swap
                        Swap(array, i, i + 1);
                        //big o is n^2
                    }
                }
            }
        }
        private static void Swap(int []array, int i, int j)
        {

            //swap is a helper method!
            //if i and j are equal we just move on
            if(i==j)
            {
                return;
            }
            //else we move and make a spare allotted container for our value
            //and swap them
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

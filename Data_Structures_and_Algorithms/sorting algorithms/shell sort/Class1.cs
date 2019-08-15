using System;
//algorithm created by donald shell in 1959
//based on insertion sort.
//insertion sort is fast on pre-sorted arrays
//basic idea of shell sort is to pre-sort the input and switch to insertion sort
//we introduce a gap. this gap is used for presorting swap distance elements
//shell sort starts witha large gap adn gradually reduces it
//when gap = 1, insertion sort finishes the sorting process

//shell sort performance depends on a concrete gap value
//in 99% of cases, you can rely on the universal sequence of gap values
//to rely on the universal sequence we need:

    /*
     * 1. to calculate the max gap < N/3 (where N is the length of array)
     * int gap = 1;
     * while (gap < array.Length /3)
     * gap = 3 * gap + 1;
     * 
     * 2. reduce gap at the end of each step of the outer loop:
     * while(gap >= 1)
     * {
     *   sort occurs..
     *   gap /= 3;
     * }
     * 
     * upon finish it yeilds: 1,4,13,40,121,364,...(1/2(3^k-1))
     */

    //shell sort is a in place algoirthm that doesnt use extra memory
    //(not dependent on n)

    //unstable as it switchs memory locations of original elements
    //can be o(n^3/2) time complexity if the sequences is (1/2(3^k-1))
    //can be up to 40% faster where o(n^6/5)

    //very good for bare metal low memory devices
public class shellSort
{
	public static void shellSort(int[] array)
	{
        int gap = 1;
        //determines inital gap size by taking array length divisible by 3
        //rounded to a whole number and then starts flipping
        while(gap < array.Length/3)
        {
            gap = 3 * gap + 1; 
        }

        //while the gap is greater or equal to one we continue on
        while (gap >= 1)
        {

            //we move up the gap by starting at the size
            for (int i = gap; i < array.Length; i++)
            {
                //we then check if our i value is >or equal to gap
                //also if our later comparison item is less than our
                //inital starting comparison item. afterwords we -=  the gap
                for (int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                {
                    //calls swap helper function
                    swap(array, j, j - gap);
                }
            }
            //after exections above are ran cuts gap by a divison of 3
            gap /= 3;
        }
	}

    public static void swap(int[] array, int i, int j)
    {
        if (i == j)
            return;

        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

using System;

//insertion sort is a stable algorithm
//uses a small amount of memory of extra memory (non dependent on n)
//o(n^2) time complexity is quadratic
//degrades quickly
public class insertionSort
{
	public static void InsertionSort(int[] array)
	{
        //we start at partition index 1 becase the 0th element is already in the sort
        //as we loop around we will eventually hit 0 again to be in the sort
        for(int partIndex = 1; partIndex < array.Length; partIndex++)
        {
            //we set the current unsorted to our partition Index
            int currentUnsorted = array[partIndex];
            //simple value to hold part index in coming loop
            int i = 0;

            //checks if i is greater than 0 and if the array index -1 value is greater
            //than the current Unsorted; we then decriment I to check
            for(i = partIndex; i >0 && array[i-1] > currentUnsorted; i--)
            {
                array[i] = array[i - 1];
            }
            array[i] = currentUnsorted;
        }
        //as a final over view we iterate to each elemeent then work backwards to fit it into
        //the correct spot. there is alot of swaps in this method making it quadratic
        //and (alot of the times) useless
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

using System;
//inplace algorithm:
//uses a small amount of extra memory (doesnt depend on n)

//selection sort is unstable
//time complexity: o(n^2) quadratic

//degrades quickly from stable to unstable
//though usually faster than bubble sort


public class selectionSort
{
	public static void selectionSort(int[] array)
	{
        //we set the part index at the end of array
        for (int partIndex = array.Length -1; partIndex > 0; partIndex--)
        {
            //selects largest value in comparison
            int largestAt = 0;

            //cycles up to part index
            for (int i = 1; i <= partIndex; i++)
            {
                if(array[i] > array[largestAt])
                {
                    largestAt = i;
                }
            }
            swap(array, largestAt, partIndex);
        }

	}

    //swapping helper function
    public static void swap(int [] array, int i, int j)
    {
        if (i == j)
            return;

        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

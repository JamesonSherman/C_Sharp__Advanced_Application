using System;

public class mergeSort
{
	public static void mergeSort(int[] array)
	{
        //divide and conquer
        //two phases splitting and merging
        //splitting is logical: provides an organized way to sequence the merges

        int[] auxArray = new int[array.Length];
        Sort(0, array.Length - 1);

        //local functions. (introduced c# 7)
        //takes beginning and end
        void Sort(int low, int high)
        {
            //if end element is equal or somehow lower than beginning we return
            if (high <= low)
                return;


            //else we add the two items and devide by 2
            //the integer allowance for these are whole numbers so no worries on odd element
            //sizes
            int mid = (high + low) / 2;
            //from here we start breaking our array into smaller units recursively
            Sort(low, mid);
            Sort(mid + 1, high);
            //finally we call the new beginning, mid, and end values
            Merge(low, mid, high);
        }

        void Merge(int low, int mid, int high)
        {
            //safeguard incase we break into one size array sets
            if (array[mid] <= array[mid + 1])
                return;


            //for merge we set i to our beginning and j to mid +1 to offset
            //to end of array
            int i = low;
            int j = mid + 1;
            //from here we array copy
            Array.Copy(array, low, auxArray, low, high - low + 1);

            //simple for loop to differentiate values moving from low to high
            for (int k = low; k <= high; k++)
            {

                //if low is greater than mid then we set array[k] element to 
                //mid+1
                if (i > mid) array[k] = auxArray[j++];

                //if mid+1 is greather than the high value we then set our array
                //value to be equal to the new low++ value
                else if (j > high) array[k] = auxArray[i++];

                //then we check if our auxillary mid+1 is less than aux low
                //if so array item is set to the aux array mid+1 new value
                else if (auxArray[j] < auxArray[i]) array[k] = auxArray[j++];
                //else we just set array item equal to the next low value moving up
                //our low to high sequence
                else array[k] = auxArray[i++];
            }
        }
	}
    //standard swap :^) very complex. much difficulty.
    public static void swap(int[] array, int i, int j)
    {
        if (i == j)
            return;

        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

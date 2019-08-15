using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class quickSort
{
	public quickSort(int[] array)
	{
        //divide and conquer approach
        //recursive
        //splitting based on pivot elements
        //elements < pivot go to its left
        //elements > go right


        //it is an inplace algorithm
        //it is a small amount of extra memory (non n dependent)
        //o(nlogn) time complexity (linerarithmic)
        //o(n^2) time complexity (quadratic) -extremely rare case
        //unstable

        Sort(0, array.Length - 1);
        //sort is a simple recursive local function that allows us to call partiton and sort our array into sides. basically our pivot is gotten with our partiton function
        // and sort is then called on both wings of our array beginning to pivot and pivot to end.
        void Sort(int low, int high)
        {
            if (high <= low)
                return;

            int j = Partition(low, high);
            Sort(low, j - 1);
            Sort(j + 1, high);
        }
        //partition helps us gather  a midpoint and swap data!
        int Partiton(int low, int high)
        {
            int i = low;
            int j = high + 1;
            //our pivot value starts at the value of the array 0th element
            int pivot = array[low];
            while(true)
            {
                while(array[++i] < pivot) //while our array beginning +1 is less than the pivot then check to see if i == high. breaks our swap case if so
                {
                    if (i == high)
                        break;
                }
                while(pivot < array[--j])  // we then check if pivot value is less than our end 
                {
                    if (j == low)  //if j is equal to our inital beginning value we break case
                        break;
                }

                if (i >= j)  //if beginning is greater than end we break
                    break;

                swap(array, i, j); //otherwise we swap!
            }

            swap(array, low, j); // in the case that we are broken from our parent while loop we swap and then return j as our partiton pivot point.
            return j;
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

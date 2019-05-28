using System;
using System.Collections;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[10];
            for (int i = 0; i < 10; i++){
                nums[i] = i + 10;
            }

            int counter = 0;
            foreach(int k in nums){
                Console.WriteLine("Element {0} - {1}", arg0: counter, arg1: k); counter++;
            }

            //declare 2d array
            string[,] matrix;

            //3d array
            int[,,] cube_matrix;

            int[,] squareMatrix = new int[,]
            {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            };

            Console.WriteLine("central value is {0}", arg0: squareMatrix[0,0]);

            //jagged array
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];

            jaggedArray[0] = new int[] {1,2,3,4,5};
            jaggedArray[1] = new int[] {1,2,3};
            jaggedArray[2] = new int[] {1,2};

            Console.WriteLine("the value in the middle of the first entry is {0}", arg0: jaggedArray[0][2]);
            //loop for iteration over jagged array items 0^n
            for(int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine("Element {0}", arg0: i);
                for(int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine("{0}", arg0: jaggedArray[i][j]);
                }
            }

            //declaring an array list
            //uses system.collections;
            ArrayList myArrayList = new ArrayList();
            ArrayList myArrayListTwo = new ArrayList(100);

            myArrayList.Add(25);
            myArrayList.Add("hello");
            myArrayList.Add(13.36);
            myArrayList.Add('C');
            myArrayList.Add(24);

            //delete element with specifc entry from array list or specific value
            myArrayList.Remove(25);
            //delete at specifc index
            myArrayList.RemoveAt(0);

           Console.WriteLine(myArrayList.Count);

            double result = 0;
           foreach(object obj in myArrayList)
           {
               if(obj is int)
               {
                   result += Convert.ToDouble(obj);
               }else if (obj is double)
               {
                    result += (double)obj;
               }else if (obj is string)
               {
                   Console.WriteLine(obj);
               }
           }


           Console.WriteLine(result);
        }
    }
}

using System;
/*How arrays are stored
 * take this example code:
 * var builders = new Stringbuild[4];
 * builders[0] = new String Builder("b1");
 * builders[1] = new String Builder("b2");
 * 
 * int[] numbers = new int[4];
 * numbers[0] = 5;
 * numbers[1] = 7;
 * numbers[2] = 1;
 * numbers[3] = 4;
 * 
 * builders and numbers are stored into the stack while memory addresses are stored somewhere
 * contiguously on the heap. string builders are stored in an area of memory witha  builder
 * prototype that references the specific string builder sucha s builder[0] and [1].
 * because we declared a 4 allotment the next two spaces not holding builder prototypes 
 * are stored as null until needed.
 * 
 * as a side note the size alloted for these spaces is different on 32bit and 64 bit machines
 * on 32 bits 4 bytes are alloted for the reference call and 8 bytes on 64 bit machines.
 * 
 * other methods such as syncBlockIndex works on this pattern of byte storage as well
 * SyncBlockIndex(4 bytes) + ref to method table(4 bytes) + length(4 bytes)
 * on our example code on a 32 bit machine
 * 
 * yet this 32 bit value is not indiciative of a base empty array of our 4 slot size.
 * even an EMPTY syncBlockIndex requires byte size storage
 * 
 * SyncBlockIndex(4bytes) + method table ref(4bytes)+Length(4bytes) + TypeHandle(4bytes)
 * = 16 bytes. This 16 bytes value is used before string values are even stored
 * 
 * 
 * numbers however can store direct values in our case 5,7,1,4 are all stored in contiguous
 * memory locations and act direct values in memory.
 * this correlates down to this formula with the specific bit of machine
 * (4*4 bytes +12) = 28 bytes [32 bit machine]
 * 
 * as far as order of growth we can iterate over an array using a simple calculation
 * take:
 * i0=70,i1=10,i2=9
 * we can start at address =0x04 in ASCII, element size =4bytes(integers)
 * and do simple addition and multiplicaiton to find our contiguous memory slots
 * address of array[0] = 0x04
 * address of array[1] = 0x04 +(1*4) = 0x08
 * address of array[2] = 0x04 +(2*4) = 0x0C
 *
 */
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //   ArrayDemo();
            //  Test1BasedArray();
            // JaggedArrays();
            //Console.Read();

            IterateOver(new[] { 1, 2, 3 });
            Console.Read();
        }


        private static unsafe void IterateOver(int[] array)
        {
            /*
             * Managed Code
                Managed code is that code that executes under the supervision of the CLR. The CLR is responsible for various housekeeping tasks, like:
                Managing memory for the objects
                Performing type verification
                Doing garbage collection

               Unmanaged Code
                On the other hand, unmanaged code is code that executes outside the context of the CLR. The best example of this is our 
                traditional Win32 DLLs like kernel32.dll and user32.dll.
                In unmanaged code a programmer is responsible for:
                Calling the memory allocation function
                Making sure that the casting is done right
                Making sure that the memory is released when the work is done
                Now to understand what UnsafeMode is.

                Definition of Unsafe Mode
                Unsafe is a C# programming language keyword to denote a section of code that is not managed by the Common Language Runtime (CLR) 
                of the .NET Framework

            to use unsafe code check the appilcation properties, under build mark use unsafe code
             */
             fixed(int * b = array)
            {
                //tells garbage collector to not move the block of code
                //takes the fixed pointer of b that points to array.
                int* p = b;
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(*p);
                    p++;
                }
            }

        }
        private static void ArrayDemo()
        {
            int[] a1; //decleration of a simple array. at this stat has no point to memory
            //types of arrays V
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 2, 3,4,5};

            int[] a4 = { 1, 2, 3 };
            //types are derived from System.Array
            

            for(int i = 0; i <= a3.Length - 1; i++)
            {
                Console.WriteLine($"{a3[i]}");
            }

            Console.WriteLine();

            foreach (var i in a4)  //foreach iteration through arrays
            {
                Console.Write($"{i}");
            }


            Array myarray = new int[5];
            // new type of creation where you create instance with type of and a size
            Array myarray2 = Array.CreateInstance(typeof(int), 5);
            myarray2.SetValue(1, 0);

            Console.Read();
        }

        private static void Test1BasedArray()  //simple create instance of a array
        {//also examples of lower and upper bound
            Array myArray = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });

            myArray.SetValue(2019,1);
            myArray.SetValue(2019,2);
            myArray.SetValue(2019,3);
            myArray.SetValue(2019,4);
           

            Console.WriteLine($"Starting index:{myArray.GetLowerBound(0)}");
            Console.WriteLine($"Ending index:{myArray.GetUpperBound(0)}");

            //you can run this to find the size of an array incase you dont know
            //for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++) ;
            //otherwise a normal for is a type o(n)

            for(int i=1; i <5; i++)
            {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }
        }

        private static void MultiDimArrays() // heavy multi dimensional arrays
        {
            //multi dim array
            int[,] r1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] r2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < r2.GetLength(0); i++)
            {
                for (int j = 0; j < r2.GetLength(1); j++)
                {
                    Console.WriteLine($"{r2[i, j]}");
                }
                Console.WriteLine();
            }
        }

        private static void JaggedArrays()
        {//jagged array examples
            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[2];

            Console.WriteLine("enter the numbers for jagged array");

            for (int  i = 0; i <jaggedArray.Length; i++)
            {
                Console.WriteLine($"array size is {jaggedArray[i].Length}");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    string st = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(st);
                }
                Console.WriteLine($"ending an array of size {jaggedArray[i].Length}");
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine(jaggedArray[i][j]);
                    Console.WriteLine("\0");
                }


            }
        }
    }

    /*closing notes
     * access elements eaither direct hit or search
     */
}


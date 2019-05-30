using System;
using System.Collections.Generic;  //always include this for list
namespace lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>(); //type of list without value
            var numbers_2 = new List<int>{1,5,35,100}; //list with type int values

            numbers.Add(7);
            numbers.Remove(7);
            numbers.Add(8);

            sbyte index = 0;
            numbers.RemoveAt(index); //remove at specifc index

            var newlist = new List<int>();
            numbers.Add(35);
            int value = numbers[0]; //now will be 35

            numbers.Clear(); //deletes every elements


            //iteration through a list
            var loop = new List<int>{5,10,15,25,30,35,40,45,50};
            //foreach way
            foreach(int element in numbers)
            {
                Console.Write(element);
            }

            //for loop way
            for(sbyte i =0; i < loop.Count; i++)
            {
                Console.Write(loop[i]);
            }

            //adding a range of values to a list
            int[] array = new int[] {1,2,3};
            numbers.AddRange(array);

            //you can also concatenate two arrays like so
            numbers_2.AddRange(loop);

            //sorting
            numbers_2.Sort();

            //true for all
            bool res = numbers_2.TrueForAll(el => el%2 ==0);

            //contains
            numbers_2.Add(4);
            Console.WriteLine(numbers_2.Contains(4)); //t or f


            int temp = numbers_2.FindIndex(x => x ==4);
            System.Console.WriteLine(numbers_2[temp]);

            //DIFFERENCES IN ARRAYLISTS, LISTS, ARRAYS

            int[] scores = new int[] {99,96,87,76};
            List<int> list = new List<int> {1,2,3,4};
                
            list.ForEach(i => Console.WriteLine(i));
            //lists are limited to typing


            //ArrayLists
            //arraylists makes code consistency hard
            //more memory intensive
            System.Collections.ArrayList arraylist = new System.Collections.ArrayList();
            arraylist.Add(1);
            arraylist.Add("two");
            arraylist.Add("3");
            arraylist.Add('a');
            arraylist.Add(3.4);
            arraylist.Add(new numbers{ n = 4});

            foreach(Object o in arraylist)
            {
                System.Console.WriteLine(o);
            }
        }
    }

    class numbers
    {
        public int n {get; set;}

        public override string ToString()
        {
            return n.ToString();
        }
    }
}

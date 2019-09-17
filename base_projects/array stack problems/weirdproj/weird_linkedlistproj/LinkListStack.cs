using System;
using System.Collections.Generic;
using System.Text;

namespace weird_linkedlistproj
{
   internal class LinkListStack
    {
        //this was initally a link stack. boy trying to reverse and manipulate that via Node based memory allocation was a  P A I N. Really though I shouldnt be coding 
        //in the wee hours of the morning. I only do it because I like ya todd.

        const int initalAlloc = 1;
        internal int[] stackarray = new int[initalAlloc];
        private int Nodecount = 0;
        int top;

        public void size() { Console.WriteLine("current size is: {0}", stackarray.Length); }
        public void CurrentTop() { Console.WriteLine("Current top of stack: {0}", top); }
        internal void Push (int value)
        {
            if (Nodecount == stackarray.Length)
            {
                //where you'd put your c++ resizing code. because well c++ is dumb and c# is vastly superior.
                Array.Resize(ref stackarray, Nodecount +1);
            }

            stackarray[Nodecount] = value;
            top = stackarray[Nodecount];
            Console.WriteLine("Added value: {0}", value);
            Nodecount++;
        }

        internal void Pop ()
        {
            //this is going to be awful but put whatever simple pop c++ mechanism you have.
            //mine is simple because again, c# VASTLY Superior.
            Console.WriteLine("resizing and deallocating current top: {0}", stackarray[stackarray.Length-1]);
            Array.Resize(ref stackarray, stackarray.Length-1);
            Nodecount--;

            top = stackarray[Nodecount-1];
        }
        
        //peek useful stack tool. checks top stack value with error handling
        internal void Peek()
        {
            if (Nodecount == 0)
            {
                Console.WriteLine("Stack Underflow Error: Array Empty");
            }

            Console.WriteLine("Current top: {0}", top);
            
        }

        //returns peek with 0 as a cautionary value and warning check
        internal int ReturningPeek()
        {
            if (Nodecount == 0)
            {
                Console.WriteLine("Stack Underflow Error: Array Empty");
                return 0;
            }
            Console.WriteLine("Current top: {0}", top);
            return top;
        }

        //scans the array for current stack value
        internal void scan()
        {
           for(int i = 0; i < stackarray.Length; i++)
            {
                Console.WriteLine("index value {0}: {1}",i,stackarray[i]);
            }
        }

        //maintain bottom element at end
        internal void bottomtoendpush(int value)
        {
            int temp;

            if (Nodecount == stackarray.Length)
            {
                //where you'd put your c++ resizing code. because well c++ is dumb and c# is vastly superior.
                Array.Resize(ref stackarray, Nodecount + 1);
            }

            if(Nodecount == 0)
            {
                //if the nodecount is 0 we need to set the 0th value to the entry. post we update top to current value and then increase nodecount.
                stackarray[Nodecount] = value;
                top = stackarray[Nodecount];
                Console.WriteLine("Added value: {0}", value);
                Nodecount++;
            }
            else
            {
                //we set a temp value to hold our bottom stack val.
                //we then set the nodecount to the bottom stack value.
                //next we set the nodecount -1 [prev index] to the concurrent value.
                //finally we update the value system.
                temp = stackarray[Nodecount - 1];
                stackarray[Nodecount] = temp;
                stackarray[Nodecount -1 ] = value;
                Console.WriteLine("Added value: {0}", value);
                top = stackarray[Nodecount];
                Nodecount++;
            }
        }

        //top to bottom
       internal void topToBottom(int value)
        {
            if (Nodecount == stackarray.Length)
            {
                //where you'd put your c++ resizing code. because well c++ is dumb and c# is vastly superior.
                Array.Resize(ref stackarray, Nodecount + 1);
            }
            if (Nodecount == 0)
            {
                //if the nodecount is 0 we need to set the 0th value to the entry. post we update top to current value and then increase nodecount.
                stackarray[Nodecount] = value;
                top = stackarray[Nodecount];
                Console.WriteLine("Added value: {0}", value);
                Nodecount++;
            }
            else
            {
                //first we integrate the concurrent value

                stackarray[Nodecount] = value;
                
                
                Console.WriteLine("Added value: {0}", value);

                //here we set up some temp vars. size and temp and temp 1.

                //size is the total of concurrent elements being held in array memory.
                //temp is just the final index value. temp 1 is a place holder.
                int size = (stackarray.Length - 1);
                int temp = stackarray[size],temp1;

                //iterate through all element and do index shifting with gross 0(n) for everycall. 
                for(int i = 0; i < size+1 ;i++)
                {
                    //we set the temp1 value to our index of 0
                    //then change stackarray[i] to temp which is the indexing value of size.
                    //finally temp becomes temp1 and we iterate.
                    temp1 = stackarray[i];
                    stackarray[i] = temp;
                    temp = temp1;
                }
                //next we update top of stack because we are nice and consistent with our public declerative methods. 
                top = stackarray[Nodecount];
                Nodecount++;

            }

        }

        
    }
}

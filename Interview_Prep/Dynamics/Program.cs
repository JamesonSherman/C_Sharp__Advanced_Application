using System;
/*
 * c# is normally statically typed
 * 
 * static languages handle type resolution at compile time
 * dynamic languages handle type resolution at run time
 * 
 * benefits
 * static languages: early feedback less unit testing
 * 
 * dynamic languages: minimal feed back , faster , and lots of testing
 * 
 * .Net 4 added the dynamic capability, to improve interoperability with
 * COM (eg writing office applications)
 * and Dynamic languages (IronPython)
 * 
 * without dynamic programming you have to use reflection.
 * 
 */
namespace Dynamics
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * suprisingly, the clr that sits under the hood of c# actually has a dynamic language runtime aptly titled
             * DLR. this sits above the CLR and helps with dynamic types.
             * 
             */
            //benefits of dynamics is that dynamics allow us to have similar usability of values similar to js or python.
            //you can just change the value and value type on the go willy nilly.

            dynamic name = "james";
            name = 10;
            name++;

            dynamic  integer = 10; //initalized as 10

            //we can change the dynamic type as much as we want but as long as it is the correct value before apss or use we can use it.
            integer = "10";
            integer = 10.00f;
            integer = 10;

            dynamic outint;
            Console.WriteLine(name);
            
            //we can even pass the dynamic as a reference type
           dynamic test2 =  multiply(ref integer);

            Console.WriteLine(test2); //outputs 100


            //we can even have out values be passed as dynamic.
            dynamic test3 = outmultiply(out outint);
            Console.WriteLine(test3);
        }




       static internal dynamic multiply(ref dynamic val)

        {

            dynamic newval = val * val;

            return newval;
            
        }

        static internal dynamic outmultiply(out dynamic val)
        {
            val = 5;

            return val += val;

        }
    }



}

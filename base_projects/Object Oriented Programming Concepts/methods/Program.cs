using System;

namespace methods
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("please enter a number");
           string userInput = Console.ReadLine();

          

            try //try starter statment for intro block
            {
                int userInputasInt = int.Parse(userInput);
            }
            catch (System.Exception) //system.exception handles general exceptions
            //usually contains a throw block;
            {
                Console.WriteLine("Format exception, please enter the correct type");
            }
            catch (OverflowException) //overflow handles over spilling or underspilling numerics
            {
                Console.WriteLine("Overflow exception, the number was too long or short");
            }
            catch (ArgumentNullException) //this exception handles null data
            {
                Console.WriteLine("ArgumentNullException, the Value was empty(null)");
            }
            finally // occurs last and is the final case to run
            {
                Console.WriteLine("this is called anyways");
            }

           Console.ReadKey();

            
        }
    }
}

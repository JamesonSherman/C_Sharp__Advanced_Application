using System;
using System.Threading.Tasks;
using System.IO;
namespace io_files
{
    class Program
    {
        static void Main(string[] args)
        {
            //need filepath
            string text = System.IO.File.ReadAllText(@"hello.txt");
            Console.WriteLine("text file contains: {0}", text);


            //seperate system for writing by multi line statments
            string[] lines = System.IO.File.ReadAllLines(@"hello.txt");
            System.Console.WriteLine("text file contains:");
            foreach(string line in lines)
            {
                Console.WriteLine("\t {0}", line);
            }

            //writing files by array
            string[] writeLines = {"first line", "second line", "third line"};
            File.WriteAllLines(@"hello2.txt", writeLines);
            
            System.Console.WriteLine("input a filename and input");
            string filename = Console.ReadLine();
            string input = Console.ReadLine();

            //this is a interesting tidbit. allows creation of file types
            //with direct extension naming
            File.WriteAllText(@"" + filename + ".txt", input);


            //method 3
            //allows for selective writing
            using(StreamWriter file = new StreamWriter(@"gossip.txt"))
            {
                foreach(string key in lines)
                {
                    if(key.Contains("third"))
                    {
                        file.WriteLine(key);
                    }
                }
            }
        }
    }
}

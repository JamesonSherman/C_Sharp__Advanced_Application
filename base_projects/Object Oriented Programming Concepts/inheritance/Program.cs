using System;

namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
           Post post1 = new Post("Thanks for the birthday wishes", true, "James Sherman");
           Console.WriteLine(post1.ToString());

           ImagePost imagepost1 = new ImagePost("Check out my new Shoes", "James Sherman",
           "https://etc.com/shoes",true);

           Console.WriteLine(imagepost1.ToString());

        }
    }
}

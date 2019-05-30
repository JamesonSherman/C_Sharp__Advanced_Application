using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structs
{

    struct Game
    {
        public string name;
        public string developer;
        public double rating;
        public string releaseDate;
        //no default constructors but can have other types of constructors.
        //cant be inherited eaither

        /*
        good reference case use:
        It logically represents a single value, similar to primitive types
        (integer, double, and so on).

        It has an instance size smaller than 16 bytes.

        It is immutable.

        It will not have to be boxed frequently.


        Is the main responsability of the type data storage?

        Is its public interface defined entirely by properties that access or modify its data members?

        Are you sure your type will never have subclasses?

        Are you sure your type will never be treated polymorphically?
        
        if these are met use a struct otherwise a class.
         */
        public Game(string name, string developer, double rating, string releaseDate)
        {
            this.name = name;
            this.developer = developer;
            this.rating = rating;
            this.releaseDate = releaseDate;
        }


        public void display()
        {
            System.Console.WriteLine("game 1's name {0}", name);
            System.Console.WriteLine("developers name {0}", developer);
            System.Console.WriteLine("rating: {0}",rating );
        }
    }


    class Program
    {
       static void Main(string[] args)
        {
            Game game1;

            game1.name = "pokemon go";
            game1.developer = "nyantic";
            game1.rating = 5.0;
            game1.releaseDate = "01.0.7.2016";

            //requires all values to be assigned prior to use
            game1.display();
        }
    }
}

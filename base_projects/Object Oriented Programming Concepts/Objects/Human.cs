using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects 
{
    class Human
    {
        //const member variable
        private const string V = "";
        //member variables
        private string firstName = V;
        private string lastName = V;
        private int age = 25;
        private int favoriteNumber = 11;
        private int leastFavoriteNumber = 9;

        //property syntax
        //short version
        public int Favorite_Number { get; set; }

        //long version
        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                if(value < 0)throw new Exception("Size should be positive");
                age = value;
            }
        }

        //simpler property synax
        //arrow notation refers to return typing
        public int LeastFavoriteNumber
        {
            get => leastFavoriteNumber;
            set => leastFavoriteNumber = value;
        }

        //constructor
        //default constructor
        public Human()
        {
            System.Console.WriteLine("Human Constructor");
        }

        //perameterized constructor
        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        //introduction method
        public void introduceMyself() => Console.WriteLine("Hi, I'm {0} {1}", arg0: firstName, arg1: lastName);
    }
}
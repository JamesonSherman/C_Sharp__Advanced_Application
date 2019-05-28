using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace polymorphism
{
    class car
    {
        public int HP { get; set;}
        public string Color {get; set;}


        public car(int peram_hp, string peram_color)
        {
            this.HP = peram_hp;
            this.Color = peram_color;
        }


        //default constructor
        public car()
        {

        }

        public virtual void ShowDetails()
        {
            Console.WriteLine("HP: {0} Color: {1}", HP, Color);
        }

        public virtual void Repair()
        {
            Console.WriteLine("car was repaired");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace polymorphism
{
    class Audi:car
    {
        private string brand = "Audi";
        public string Model {get; set;}
        public Audi(int peram_hp, string peram_color, string peram_model):base(peram_hp,peram_color)
        {
           this.Model = peram_model;
        }


        public override void ShowDetails()
        {
             Console.WriteLine("Brand: {0} HP: {1} Color: {2}",brand, HP, Color);
        }

        public override void  Repair()
        {
            Console.WriteLine("The Audi {0} was repaired", Model);
        }
    }   

}
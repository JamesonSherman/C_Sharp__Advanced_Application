using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace polymorphism
{

    //bmw and car is a is a relationship
    class BMW:car
    {
        private string brand = "BMW";
        public string Model {get; set;}
        public BMW(int peram_hp, string peram_color, string peram_model):base(peram_hp,peram_color)
        {
           this.Model = peram_model;
        }

        public override void ShowDetails()
        {
             Console.WriteLine("Brand: {0} HP: {1} Color: {2}",brand, HP, Color);
        }

        //sealed can be placed so that further inherted methods can not be over ridden.
        //sealed allows no override
        //virtual allows for override
        //you can also seal classes

        public override void Repair()
        {
            Console.WriteLine("The BMW {0} was repaired", Model);
        }
    }   

}
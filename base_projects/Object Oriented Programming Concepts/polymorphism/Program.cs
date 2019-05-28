using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {

            //instantiation of a list
            //this allows us to almost vectorize new items into the list
            var cars = new List<car>
            {
                new Audi(200, "blue", "A4"),
                new BMW(250, "red", "m3")
            };

            //foreach call to iterate through a list of cars.
            foreach(var car in cars)
            {
                car.Repair();
            }

            //assignment of objects and calling of the ShowDetails method
            car bwmZ3 = new BMW(200,"black","Z3");
            car audiA3 = new Audi(100, "green", "A3");
            bwmZ3.ShowDetails();
            audiA3.ShowDetails();

            BMW bmwM5 = new BMW(330,"white","M5");
            bmwM5.ShowDetails();

            //reassignment of object with previous objects properties
            car carb = (car)bmwM5;
            carb.ShowDetails();

            M3 myM3 = new M3(400, "red", "M3Super Turbo");
            myM3.Repair();

        }
    }
}

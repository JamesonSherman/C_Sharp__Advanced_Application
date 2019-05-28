using System;

namespace Objects
{
    class Program
    {
        static void Main(string[] args)
        {
           Human dennis = new Human("dennis", "vital");
           dennis.introduceMyself();

           Human michael = new Human("mike", "meyers");
           michael.introduceMyself();

        }
    }
}

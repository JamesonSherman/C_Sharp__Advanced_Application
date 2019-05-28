using System;

namespace finalizer_deconstrucors
{
    class Program
    {
        static void Main(string[] args)
        {
            Members member1 = new Members();
            member1.Introducting(true);
            Console.ReadKey();
        }
    }
}

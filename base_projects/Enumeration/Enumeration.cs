using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enumeration_examples
{
    /*
    main advantage of enums is that they are basically integers with some named values, 
    as such they are inherently portable and serializable.
    Arithmetic and logical operations are also faster on enums.

    Enumeration classes are used when you need an opaque value which has extra state information.
    For instance a generic Data Access Layer could have as an interface like:
    
    public enum LightColors
    {
    unknown = 0,
    red = 1,
    yellow = 2,
    green = 4,
    green_arrow = 8
    }
    
    //the single vertical bar is a bitwise or
    LightColors c = LightColors.red | LightColors.green_arrow;
    
    Enums are great for lightweight state information
     */
    enum Day { Mo, Tu, We, Th, Fr, Sa, Su};
    class Program
    {
        static void Main(string[] args)
        {
            Day fr = Day.Fr;
            Day su = Day.Su;
            Day a = Day.Fr;

            System.Console.WriteLine(fr == a);
        }
    }
}

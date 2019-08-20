using System;
using System.Collections.Generic;

/*hash functions are a one way conversion of data to a specifc hash
 * hash functions guarantees to generate the same output for the same input
 * 
 * hashing funcitons in cryptography are unfeasible to invert
 * 
 * example:
 * qwety -> (hashed) -> "a!h*yf2sm" [converted password]
 * we then get the input hash and compare against stored hash
 * */


//c# already does alot of the heavy lifting for you by
//already implementing most of the hash code functions
//outside of custom structures


//examples:
/*
//the abs value of the int contained
public override int GetHashCode()
{
    return m_value;
}

//returns hashcode for int16
public override int GetHashCode()
{
    return ((int)((ushort)m_value) | (((int)m_value) << 16));
}

// returns has code for dateTime
public override int GetHashCode()
{
    Int64 ticks = InternalTicks;
    return unchecked((int)ticks) ^ (int)(ticks >> 32);
}

//provides a hash code for boolean
public override int GetHashCode()
{
    return (m_value) ? True : False;
}

//get hash code is useful for only one thing: putting an object in a hash table

a good hash code implementaiton should be:
fast
well distributed across the space of 32 bit integers for the given
distributed inputs

do not use hash code:
as a unique key for an object: probability of collision is extremely high
as part of a digital signature or a password equivalent


*/

namespace hashing
{

    class Program
    {
        static void Main(string[] args)
        {
            var number1 = new PhoneNumber("1", "27", "123");
            var number2 = new PhoneNumber("1", "27", "123");
            var number3 = new PhoneNumber("1", "27", "123");

            Console.WriteLine(number1.GetHashCode());
            Console.WriteLine(number2.GetHashCode());
            Console.WriteLine(value:number1 == number2);
            Console.WriteLine(number1.Equals(number2));

            var customers = new Dictionary<PhoneNumber, Person>();
            customers.Add(number1, new Person());
            // customers.Add(number2, new Person());

            Console.WriteLine(customers.ContainsKey(number1));

            Console.WriteLine(value: "after adding numbers");
            //var c = customers[number3];



            Console.Read();


        }

    }
}

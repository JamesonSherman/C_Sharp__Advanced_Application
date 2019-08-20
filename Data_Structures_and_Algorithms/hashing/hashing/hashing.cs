using System;
using System.Collections.Generic;
using System.Text;


//seperate chaining where values need to go into the same array at same indexes
// we can create a linked list based up on the value is. (or a array of linked lists)
namespace hashing
{
    public class PhoneNumber
    {

        //setters removed making this immutable
        public string AreaCode { get;}
        public string Exchange { get;}
        public string Number { get;}


        public PhoneNumber(string areacode, string exchange, string number)
        {

        }

        public override bool Equals(object obj)
        {
            var testPhoneNumber = obj as PhoneNumber;
            if (testPhoneNumber == null)
                return false;

            return string.Equals(AreaCode, testPhoneNumber.AreaCode)
                && string.Equals(Exchange, testPhoneNumber.Exchange)
                && string.Equals(Number, testPhoneNumber.Number);

        }

        //side note since we are testing equivalancy and dict storage of hashes we need to overload equality values
        //if you write a equals operator overload you need to match a offkilter not equals overload as well
        //lest it wont compile
        public static bool operator ==(PhoneNumber left, PhoneNumber right)
        {
            if (object.ReferenceEquals(left, right))
                return true;

            if (object.ReferenceEquals(null, left))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(PhoneNumber left, PhoneNumber right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                //fnv theorem smallest thirty two bit hash number 
                const int HashingBase = (int)2166136261;
                //The smallest FNV prime used by the 32-bit FNV hash. [Noll]
                const int HashingMultiplier = 16777619;

                //hash equals our hash base it will be a 32 bit hash
                //formula goes (hash * hash multi) ^(hash code in ref to 0)
                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!object.ReferenceEquals(null, AreaCode) ? AreaCode.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!object.ReferenceEquals(null, Exchange) ? Exchange.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!object.ReferenceEquals(null, Number) ? Number.GetHashCode() : 0);

                return hash;
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public int SSN { get; set; }
    }
}

using System;
using System.Collections.Generic; // normal namespace of common generics.

/*
 * generics are a non type specific collection that is executed at runtime. 
 * can be used for code resuability instead of having to define multiple types of normal methods for class objects.
 * 
 * usually designated by <> marks and a non specific type identifier
 * 
 * 
 * we can put constraints to meet different types of generics needs.
 * 
 * where T: IComparable   compare objects using an interface
 * where T : Product  set objects using single inheritance from another class
 * where T : struct  set an object to a value type that can be nulled
 * where T : class  sets an object to a class
 * where T : new()  sets an object to be a reference type in the generic.
 * example:
 * 
 * public class Utility<T> where T : whateverinterfaceforuse
 * 
 * we use the where T : syntax to inherit from a specific interface we need for non type specific comparison.
 * */
namespace Generics
{
    class Program
    {
        static void Main(string[] args)

        {

            
            var book = new Book {Isbn = "1111" ,Title = "C# advanced"};

            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(new Book());

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.add("1234", new Book());

        }
    }

    //reference 1
    //simple generics
    public class GenericList<T>
    {
        public void Add(T value)
        {
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }    
    }

    public class BookList
    {
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Book this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

   
        public class Book
        {
            public string Isbn { get; set; }
            public string Title { get; set; }
        }






    //reference 2
    //dictionary
    public class GenericDictionary<Tkey, TValue>
    {
        public void add(Tkey key, TValue value)
        {

        }
    }



    //reference 3
    //constraint to an interface
    public class Utilities<T> where T: IComparable
    {

        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        //we can do comparision functions using generics similarly. 
        //the included difference from the first function and second is generics.
        //to use the methods strapped to the interface IComparable we simply inherit from it in the class name and signiture then use the compareTo method.
        public T Max(T a, T b)
        {
          return  a.CompareTo(b) > 0 ? a : b;
        }
    }


    //reference 4
    //inheritance for generics from a class
    public class DiscountCalculator<TProduct> where TProduct : Product
    {

        public float CaculuateDiscount(TProduct product)
        {
            return product.Price;
        }

    }

    public class Product
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }



    //reference 5
    //generics with structs;
    //how to set generics as null
    //sets the struct contraint that T has to be a value type
    public class Nullable<T> where T : struct
    {
        private object _value;


        public Nullable()
        {
            //empty incase nothing passed
        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueorDefault()
        {
            if (HasValue)
                return (T)_value;

            return default(T);
        }
    }


    //refrence 6
    //multiple constraints
    //sets the value to a reference type with the use of new()
    //inhertis interface Icomparable but gets reference inheritance form new()

    public class multipleConstraint<T> where T : IComparable, new()
    {
        public void DoSomething(T value)
        {
            var obj = new T();
        }
    }

}
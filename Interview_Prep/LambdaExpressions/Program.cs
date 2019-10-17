using System;
using System.Collections.Generic;
/*
 * A lambda expression is a anaonymous method that has no access modifier
 * no name
 * no return statement.
 * 
 * 
 * why do we use lambda functions?
 * Because they make our code more readable 
 * and for conveience
 * 
 * */
namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //example using func delegate 
            Func<int, int> square = number => number * number;
            //args => expression
            // number => number * number

            //if you have one parenthesis you can simply forgo having a perenthesis
            //() => ...
            //x => ...

            //multiple require perenthesis
            //(x,y,z) => ...
            const int factor = 5;
            Func<int, int> multiplier = n => n * factor;

            var result = multiplier(10);

            Console.WriteLine("Hello World!");





            //example 2
            var books = new BookRepository().GetBooks();
            var bookrepo = new BookRepository();

            var cheapbooks = books.FindAll(bookrepo.IsCheaperthan);

            foreach(var book in cheapbooks)
            {
                Console.WriteLine( book );
            }


            //example 3 with lambda
            //this implementation makes the use of the IsCheaperthan method completely useless.
            var books2 = new BookRepository();

            var lambdacheapbooks = books2.GetBooks().FindAll(book => book.Price <10);

            foreach (var book in lambdacheapbooks)
            {
                Console.WriteLine(book);
            }
        }

        //example 1
        static int Square(int number)
        {
            return number * number;
        }
    }



    //example 2
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() { Title = "title1", Price = 5},
                new Book() { Title = "title2", Price = 6},
                new Book() { Title = "title3", Price = 7}
            };
            
        }

        

        public bool IsCheaperthan(Book obj)
        {
            throw new NotImplementedException();
        }
    }

    public class Book
    {
     public   string Title { get; set; }
     public   int Price { get; set; }
    }
}

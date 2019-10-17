using System;
using System.Collections.Generic;
using System.Linq;

/*what is Linq?
* linq stands for language integrated query
* 
* gives you the ability to query objects.
* 
* things you can query with linq:
* objects in memory
* databases
* xml
* ado.net data sets
* 
* for more methods in reference to linq:
* https://www.tutorialsteacher.com/linq/linq-standard-query-operators
*/
namespace LINQ
{
    class Program

        //small linq example.
    {
        static void Main(string[] args)
        {
            var books = new BookRepo().GetBooks();
            
            //common use cases for linq order of operations is to filter, sort, select. 
            var cheapbooks = books.Where(b => b.price < 8.00f)
                                  .OrderBy(b => b.Title)  
                                  .Select(b => b.Title);

            //both the first linq iteration and the second itteration below do the same thing.
            var cheaperBooks = from b in books
                               where b.price < 10
                               orderby b.Title
                               select b.Title;

            foreach (var keybook in cheapbooks)
                //  Console.WriteLine(keybook.Title + " " + keybook.price);
                Console.WriteLine(keybook);

           
        }
    }

    public class book
    {
        public string Title { get; set; }
        public float price { get; set; }
    }

    public class BookRepo
    {

        public IEnumerable<book> GetBooks()
        {
            return new List<book>
            {
                new book() {Title = "book1", price = 5.00f},
                new book() {Title = "book2", price = 7.99f},
                new book() {Title = "book3", price = 9.45f}
            };
        }
    }
}

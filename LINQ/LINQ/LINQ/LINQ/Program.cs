using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var Linq = new Program();
            Linq.baseofLINQusingShortWords();

        }

        //Example of a LINQ query method
        public void baseofLINQusingShortWords()
        {
            string[] words = { "hello", "wonderful", "LINQ", "beautiful", "world" };

            var shortWords = from word in words where word.Length <= 5 select word;

            //Print each word out
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }


        //example of the two types of syntaxes
        public void SyntaxofLINQ()
        {
            string[] words = { "hello", "wonderful", "LINQ", "beautiful", "world" };
            //lambda syntax
            var longwords = words.Where(w => w.Length > 10);

            //query syntax
            var querylongwords = from w in words where w.Length > 10 select w;
        }

        //example of where query
        public void syntaxofWhereQueryExpression()
        {

            string[] words = { "humpty", "dumpty", "set", "on", "a", "wall" };

            IEnumerable<string> query = from word in words where word.Length == 3 select word;

            foreach (string str in query)
                Console.WriteLine(str);
            Console.ReadLine();
        }

        //example of join
        public void JoinTableLinq()
        {
            List<DepartmentClass> departments = new List<DepartmentClass>();
            departments.Add(new DepartmentClass { DepartmentId = 1, Name = "Account" });
            departments.Add(new DepartmentClass { DepartmentId = 2, Name = "Sales" });
            departments.Add(new DepartmentClass { DepartmentId = 3, Name = "Marketing" });

            List<EmployeeClass> employees = new List<EmployeeClass>();
            employees.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 1, EmployeeName = "William" });
            employees.Add(new EmployeeClass { DepartmentId = 2, EmployeeId = 2, EmployeeName = "Miley" });
            employees.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 3, EmployeeName = "Benjamin" });


            var list = (from e in employees
                        join d in departments on e.DepartmentId equals d.DepartmentId
                        select new
                        {
                            EmployeeName = e.EmployeeName,
                            DepartmentName = d.Name
                        });

            foreach (var e in list)
            {
                Console.WriteLine("Employee Name = {0} , Department Name = {1}", e.EmployeeName, e.DepartmentName);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        class DepartmentClass
        {
            public int DepartmentId { get; set; }
            public string Name { get; set; }
        }

        class EmployeeClass
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public int DepartmentId { get; set; }
        }


        //select example
        public void selectLINQexample()
        {
            List<string> words = new List<string>() { "an", "apple", "a", "day" };

            var query = from word in words select word.Substring(0, 1);

            foreach (string s in query)
                Console.WriteLine(s);
            Console.ReadLine();
        }

        //example of selectMany
        public void SelectManyLinqExample()
        {
            List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };

            var query = from phrase in phrases
                        from word in phrase.Split(' ')
                        select word;

            foreach (string s in query)
                Console.WriteLine(s);
            Console.ReadLine();
        }

        //examples of order and orderby descending
        public void orderbyandorderbydescLINQexample()
        {
            int[] num = { -20, 12, 6, 10, 0, -3, 1 };

            //create a query that obtain the values in sorted order
            var posNums = from n in num
                          orderby n
                          select n;

            Console.Write("Values in ascending order: ");

            // Execute the query and display the results.

            foreach (int i in posNums)
                Console.Write(i + " \n");

            var posNumsDesc = from n in num
                              orderby n descending
                              select n;

            Console.Write("\nValues in descending order: ");

            // Execute the query and display the results.

            foreach (int i in posNumsDesc)
                Console.Write(i + " \n");

            Console.ReadLine();
        }

        //examples of groupby
        public void examplesofGroupByforLINQ()
        {
            List<int> numbers = new List<int>() { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };

            IEnumerable<IGrouping<int, int>> query = from number in numbers
                                                     group number by number % 2;

            foreach (var group in query)
            {
                Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");

                foreach (int i in group)
                    Console.WriteLine(i);
            }

            Console.ReadLine();
        }



        //example of cast
        public void castLinqExample()
        {
            Plant[] plants = new Plant[] {new CarnivorousPlant { Name = "Venus Fly Trap", TrapType = "Snap Trap" },
                          new CarnivorousPlant { Name = "Pitcher Plant", TrapType = "Pitfall Trap" },
                          new CarnivorousPlant { Name = "Sundew", TrapType = "Flypaper Trap" },
                          new CarnivorousPlant { Name = "Waterwheel Plant", TrapType = "Snap Trap" }};

            var query = from CarnivorousPlant cPlant in plants
                        where cPlant.TrapType == "Snap Trap"
                        select cPlant;

            foreach (var e in query)
            {
                Console.WriteLine("Name = {0} , Trap Type = {1}", e.Name, e.TrapType);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        class Plant
        {
            public string Name { get; set; }
        }

        class CarnivorousPlant : Plant
        {
            public string TrapType { get; set; }
        }
    }

}


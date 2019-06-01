using System;
using System.IO;
using System.Collections.Generic;
namespace c__db_system
{
    class Program
    {
        public static void Main(string[] args)
        {
            //dbfile path combines the GPSDB.data path
            var dbFile = Path.Combine(Path.GetTempPath(), "GPSDB.data");

            try
            {
                //deletes inital files on startup for test purposes
                if (File.Exists(dbFile))
                {
                    File.Delete(dbFile);
                    Console.WriteLine("Deleted main database file");
                }

                if (File.Exists(dbFile + ".pidx"))
                {
                    File.Delete(dbFile + ".pidx");
                    Console.WriteLine("Deleted primary index file");
                }

                if (File.Exists(dbFile + ".sidx"))
                {
                    File.Delete(dbFile + ".sidx");
                    Console.WriteLine("Deleted secondary index file");
                }


                using (var db = new GPSDataBase(dbFile))
                {
                    //does two inserts of specific points and GUID values
                    db.Insert(new Location_DataModel
                    {
                        //3 things needed for model
                        /* public Guid ID {get; set;}

                           public int GPSPoint { get; set; }

                           public string location_Name {get; set;}*/
                           //
                        ID = Guid.Parse("92ea75d6-f102-40d7-9fac-4b0446d929b9"),
                        GPSPoint = 1,
                        location_Name = "LA"
                    });
 
                    db.Insert(new Location_DataModel
                    {

                        ID = Guid.Parse("2edc7296-0875-4345-87cc-79391aded3a0"),
                        GPSPoint = 2,
                        location_Name = "CA"
                    }) ;

                    Console.WriteLine("inserted new point");
                }

                using (var db = new GPSDataBase (dbFile))
                {
                    //we do two seperate searches here the db.Find method and the db.Find by method. 
                    //find checks guid values and find by checks by a tuple of location name and point
                    Console.WriteLine(" ");
                    Console.WriteLine("Found point by GUID: " + db.Find (Guid.Parse("92ea75d6-f102-40d7-9fac-4b0446d929b9")).ToString());
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");

                    Console.WriteLine("Testing SEARCH BY TUPLE LOCATION_NAME and GPSPOINT");
                    foreach(var row in db.FindBy(location_Name: "CA", GPSPoint: 2))
                    {
                        Console.WriteLine(row.ToString());
                    }
                }
            }

            finally
            {
                //finally after we complete our tasks we remove values from the db and clear file system
                if (File.Exists(dbFile))
                {
                    Console.WriteLine(" ");
                    File.Delete(dbFile);
                    Console.WriteLine("Deleted main database file");
                }

                if (File.Exists(dbFile + ".pidx"))
                {
                    Console.WriteLine(" ");
                    File.Delete(dbFile + ".pidx");
                    Console.WriteLine("Deleted primary index file");
                }

                if (File.Exists(dbFile + ".sidx"))
                {
                    Console.WriteLine(" ");
                    File.Delete(dbFile + ".sidx");
                    Console.WriteLine("Deleted secondary index file");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace c__db_system
{
    //local model for unique latitude and longitude by location name
    public class Location_DataModel
    {   //the global unique identifier or GUID is a 92ea75d6-f102-40d7-9fac-4b0446d929b9 style value that is unique and acts as a hash for finding. it is an easily traversable 
        //value with 4 splits for accuracy
        public Guid ID {get; set;}
        //gps point is a 8 bit integer value that symbolizes a gps or notification point
        public int GPSPoint { get; set; }
        //string value that represents a location title
        public string location_Name {get; set;}

        //over ridden to string that updates formatting and outputs values ina  specifc order
        public override string ToString()
        {
            return string.Format("[Location_DataModel: ID = {0} Location Point = {1} Location Name = {2}]", ID, GPSPoint, location_Name);
        }
    }
}
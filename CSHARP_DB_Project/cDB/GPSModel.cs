using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace c__db_system
{
    //local model for unique latitude and longitude by location name
    public class Location_DataModel
    {
        public Guid ID {get; set;}
        public float unique_Latitude {get; set;}
        public float unique_Longitude {get; set;}

        public string location_Name {get; set;}


        public override string ToString()
        {
            return string.Format("[Location_DataModel: ID = {0}, Latitude={1}, Longitude={2}, Location = {3}", ID, unique_Latitude, unique_Longitude, location_Name);
        }
    }
}
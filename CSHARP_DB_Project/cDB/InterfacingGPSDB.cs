
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace c__db_system
{
public interface IGPSDB
    {
        //this is a interface system for the GPSDB.
        //it allows us to make software contracts for implementation of methods later on without the necessary use of an absract class method implementation
        void insert(Location_DataModel newpoint);
        void delete(Location_DataModel point);

        void Update(Location_DataModel point);

        Location_DataModel Find (Guid id);

        IEnumerable<Location_DataModel> FindBy(string location_Name, int GPSPoint);
    }
}

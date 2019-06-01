
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace c__db_system
{
public interface IGPSDB
    {
        void insert(Location_DataModel newpoint);
        void delete(Location_DataModel point);

        void Update(Location_DataModel point);

        Location_DataModel Find (Guid id);

        IEnumerable<Location_DataModel> findBy (float unique_Latitude, 
        float unique_Longitude, string location_Name);
    }
}

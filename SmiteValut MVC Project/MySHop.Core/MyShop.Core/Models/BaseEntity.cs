using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    //base entity class used for inheritance to Product.cs and ProductCategory.cs
    //this is the base class used for the generic in InMemoryRepository.cs from MyShop.DataAccess.InMemory
    public class BaseEntity
    {
        //sets a GUID genuine Unique ID
        public String ID { get; set; }

        //creates a DateTimeOffset for when the class was created. 
        public DateTimeOffset CreatedAt { get; set; }

        //constructor implementation for creating the individuals GUID's and for setting our DateTimeOffset. 
        public BaseEntity()
        {
            this.ID = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }
    }
}

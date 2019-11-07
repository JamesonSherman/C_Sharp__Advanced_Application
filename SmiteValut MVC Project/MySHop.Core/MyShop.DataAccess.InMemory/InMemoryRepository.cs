using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    // implementes T as a object or sub object of BaseEntity from MyShop.Core
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        //creates a cache system from System.Runtime.Caching. this cache allows us to store values in local memory. 
        ObjectCache cache = MemoryCache.Default;
        //list of generic items T.
        List<T> items;
        //simple className string used for reflection.
        string className;

        //using Type Reflection we get the className by useing Typeof(T).Name from the internal details of the passed item.
        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;

            if (items == null)
            {
                items = new List<T>();
            }
        }

        //omit system for storing data into the cache. takes the className from the data reflection 
        //sets the cache to that class name and adds items.
        public void Commit()
        {
            cache[className] = items;
        }

        //inserts items of Type T into the items list.
        public void Insert(T t)
        {
            items.Add(t);
        }

        //allows update of item based on the ID of the passed item.
        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.ID == t.ID);

            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + "Not Found. Cannot update.");
            }
        }

        //finds a item based upon a given id and returns the item.
        public T Find(string Id)
        {
            T t = items.Find(i => i.ID == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + "Not Found");
            }
        }

        //returns all items AsQueryable
        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        //deletes a specified item based upon Id.  
        public void Delete(string Id)
        {
            T tToDelete = items.Find(i => i.ID == Id);
            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className + "Not Found. Can not delete.");
            }
        }
    }
}

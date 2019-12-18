using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    //we implement the Irepository interface where our generic of T is a base or inheretied class from BaseEntity.
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        //sets a datacontext 
        internal DataContext context;
        //creates a DbSet
        internal DbSet<T> dbset;

        //constructor for our SQL repo that sets context and the dbset accoriding to the passed generic
        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbset = context.Set<T>();
        }

        //just returns a queryable dbset via our current DbSet<T>
        public IQueryable<T> Collection()
        {
            return dbset;
        }

        //saves changes of our database.
        public void Commit()
        {
            context.SaveChanges();
        }

        //deletes items based upon passed Id. we check the state and see if its detached. if so we attach then remove
        //otherwise just remove it from the database.
        public void Delete(string Id)
        {
            var t = Find(Id);
            if(context.Entry(t).State == EntityState.Detached)
            {
                dbset.Attach(t);
            }

            dbset.Remove(t);
        }
        
        //returns a specific item based on the GUID passed to the find method.
        public T Find(string Id)
        {
            return dbset.Find(Id);
        }
        //simply adds an item of T to the dbset.
        public void Insert(T t)
        {
            dbset.Add(t);
        }

        //update method for our database
        //first we pass in T generic type and attach it to the databaseset. afterwords we update the context
        //through the entry and state functions. we then set the entity state to be EntityState.Modified.
        public void Update(T t)
        {
            dbset.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}

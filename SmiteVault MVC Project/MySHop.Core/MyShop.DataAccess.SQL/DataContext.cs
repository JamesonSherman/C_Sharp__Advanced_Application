using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        //creates a datacontext to my SQL Database hosted on microsoft Azure
        public DataContext()
            :base("AddCustomConnectionNameHere")
        {

        }

        //sets a DbSet of products and product categories.
        //the inital migration used for this allows the migration to auto generate a create table.
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}

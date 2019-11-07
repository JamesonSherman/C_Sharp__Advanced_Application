This class library implements both Entity Framework , Code First Migrations, and SQL connection context.

Assemblies used in this library:
[
System.Net.Http
EntityFramework
EntityFramework.SqlServer
]

Refrence class libraries used:
[
MyShop.Core/Models
Basket.cs  - basket model for entity code first migrations refrenced in migration: BasketItems.cs
BasketItem.cs - basket Item model for entity code first migrations refrenced in migration: BasketItems.cs 
Product.cs - Product model for Entity code first migrations referenced in Inital Migration and UpdateStrLength Migration
ProductCategory.cs - Product Category Model for Entity code first migrations referenced in Inital Migration.
]

Relevent Files used:
[
App.config - connection string location. If another user wishes to implement the files and UI project involved this connection string will need to be updated accordingly.
DataContext.cs - Azure database hookup reading from App.config

implements the following DbSets and Related Startups:

 public DataContext()
            :base("SpellList")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

		DbSets implemented from MyShop.Core/Models listings.


SQLRepository.cs - This file implements a number of methods in relation to our DataContext hookup.
As a primary note
We implement all passable items as a generic of T where T is eaither a root class of BaseEntity or a subclass in context.
Example:
SQLRepository<T> : IRepository<T> where T : BaseEntity

Other Relevent Methods

IQueryable<T> Collection - returns all values in relation to the collection
Commit - saves changes to a database
Delete - Deletes a item from the database. Does a Entity Detachment Check Beforehand
Find - Looks up a specific passed ID sent to the find.
Update - updates data within the database of altered columns.
]
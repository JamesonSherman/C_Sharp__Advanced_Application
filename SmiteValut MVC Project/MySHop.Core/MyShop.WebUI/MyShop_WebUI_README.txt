This is the user interface of the application.

Standard items such as implementations for SQL ,Models, and ViewModels have been abstracted to class libraries in earlier projects in the solution.

UI BREAKDOWN
[
Models and Viewmodels
Imported from MyShop.Core/Models && My.Shop.Core/ViewModels respectively.

Controllers:
Account Controller -Unused base controller for accounts included in ASP.NET MVC project build
BasketController - logic to pass views of items inside the basket to the Index page of Basket Views
HomeController - Modified controller to display a list of all products as well as a category search bar.
ManageController - unused controller for Managment systems included in ASP.NET MVC project build
ProductCategoryManagerController - This controller controls all of our category setup and display information. It has 3 major functions as well as a search implemented in views Create Delete Edit and Index under MyShop.WebUI/Views/ProductCategoryManager
ProductManagerController - This controller, similar to ProductCategoryManagerController implements Create Delete Edit and Search methods as well. These views can be found under MyShop.WebUI/Views/ProductManager

Other Views:
Shared Views contains an editied layout system for display the basket system as well as product and product category manager tabs.These link to respective controllers.


Other Notes:
If this project is to be reimplimented elsewhere, Webconfig must be updated to match. The connection String in this project has been removed as to not give away my connection string to Azure Database. 

Under MyShop.WebUI/App_Start/UnityConfig.cs is a listing of all my Unity Dependency Constructor Injection setups. This file allows us to use UNITY DI to cast values to constructors upon build and use through said dependency injection.

These container Registered types are as such:
  container.RegisterType<IRepository<Product>, SQLRepository<Product>>();
  container.RegisterType<IRepository<ProductCategory>, SQLRepository<ProductCategory>>();
  container.RegisterType<IRepository<Basket>, SQLRepository<Basket>>();
  container.RegisterType<IRepository<BasketItem>, SQLRepository<BasketItem>>();
  container.RegisterType<IBasketService, BasketService > ();

  References:
  This WebUI implements multiple class libraries: MyShop.Core, MyShop.DataAccess.InMemory (Deprecated), MyShop.DataAcess.SQL, MyShop.Services
  
  This project also impliments Unity.MVC and Unity.Container from NuGET Package Manager System. 
]
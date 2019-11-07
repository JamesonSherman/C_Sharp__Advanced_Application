this class library project is an earlier iteration prior to Azure database connection with Entity Framework. 

Assemblies Used:
[
System.Runtime.Caching - used for local memory storage of items prior to Azure db hookup.
]

Reference Projects Used:
[
MyShop.Core/Models
Product.cs
ProductCategory.cs

MyShop.Core/ViewModels
ProductListViewModel.cs
ProductManagerviewModel.cs
]

This project currently contains:
[
InMemoryRepository.cs - previously used cache system to store data and models in memory. Used System.Runtime.Caching and models for storing and looking at data.
]
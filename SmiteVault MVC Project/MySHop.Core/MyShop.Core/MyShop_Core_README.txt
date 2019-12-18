this class library project is the base models and view models folder. 
This project currently contains:
[
MyShop.Core/Models/
BaseEntity.cs - base class for creation of future models. Includes GUID creation and TimeStamp.
Basket.cs - basket class inherits from BaseEntity. Used for storage of an Icollection for BasketItem.cs
BasketItem.cs - basketItem class inherits from BaseEntity. used to store basketId, itemId and quantity.
Product.cs - product class inherits from BaseEntity. used to store name, description,price, Image, and category atributes of an item.
ProductCategory.cs - prudctCategory class inherits from base entity. Used to store category data.

/MyShop.Core/ViewModels
ProductListViewModel.cs -view model to list IEumerable products and product categories.
ProductManagerViewModel.cs - view model to display products and an Ienumerable fo product categories.
BasketItemView Model.cs - view model to display an Item in a user basket.
BasketSummaryViewModel - view model designated to display a summar of items in a current basket.
]
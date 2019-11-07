using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.Services
{
   public class BasketService : IBasketService
    {
        //creates two IRepos based on product context and basket context.
        IRepository<Product> productContext;
        IRepository<Basket> basketContext;

        //declare a base string to pass in for use in HttpCookie call
        public const string BasketSessionName = "ItemBasket";

        //constructor setting our I Repo's to the passed in constructor repos using this context.
        public BasketService(IRepository<Product> ProductContext, IRepository<Basket> BasketContext)
        {
            this.basketContext = BasketContext;
            this.productContext = ProductContext;
        }

        //gets a basket. sends in a httpContextBase and a bool to check if the basket is non existant
        private Basket GetBasket(HttpContextBase httpContext, bool createIfNull)
        {
            //creates a http cookie based on httpcontext request. we pass in the basketSessionName
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);
            Basket basket = new Basket();
            //if the cookie is not null
            //we create a basketId based upon the cookie value.
            if(cookie != null)
            {
                string basketId = cookie.Value;

                //we then check if the basket id is null or empty based upon our cookie value
                //if not then we set our basket declared earlier to the basketContext. else we create a new basket.
                if(! string.IsNullOrEmpty(basketId))
                {
                    basket = basketContext.Find(basketId);
                }
                else
                {
                    if(createIfNull)
                    {
                        basket = CreateNewBasket(httpContext);
                    }
                }
            }
            else
            {
                //if the cookie is null we just skip the above and make a new basket and then return the basket.
                basket = CreateNewBasket(httpContext);
            }
            return basket;
        }

        //creates a new basket, sets our cookie value to the basket GUID and adds a cookie expiration date.
        private Basket CreateNewBasket(HttpContextBase httpContext)
        {
            Basket basket = new Basket();
            basketContext.Insert(basket);
            basketContext.Commit();

            HttpCookie cookie = new HttpCookie(BasketSessionName);
            cookie.Value = basket.ID;
            cookie.Expires = DateTime.Now.AddDays(7);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }

        //adds item to basket. does a check if the item is null in basket. if so adds item to the basket. otherwise updates quantity of said item. commits post operation
        public void AddToBasket(HttpContextBase httpContext,string productId)
        {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.ProductId == productId);

            if(item == null)
            {
                item = new BasketItem()
                {
                    BasketId = basket.ID,
                    ProductId = productId,
                    Quantity = 1,
                };

                basket.BasketItems.Add(item);
            }
            else
            {
                item.Quantity = item.Quantity + 1;
            }

            basketContext.Commit();
        }

        //removes an item from the basket based upon if the item is not null. calls 
        public void RemoveFromBasket(HttpContextBase httpContext, string itemId)
        {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item= basket.BasketItems.FirstOrDefault(i => i.ID == itemId);

            if(item != null)
            {
                basket.BasketItems.Remove(item);
                basketContext.Commit();
            }

        }

        //gathers all basket items based upon a LinQ query. we get our result based upon items from product table and set them to our item for the basket.
        //else we just return a new list with the basketItemViewModel
        public List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext, false);

            if(basket != null)
            {
                var result = (from b in basket.BasketItems
                              join p in productContext.Collection() on b.ProductId equals p.ID
                              select new BasketItemViewModel()
                              {
                                  Id = b.ID,
                                  Quantity = b.Quantity,
                                  ProductName = p.Name,
                                  Image = p.Image,
                                  price = p.Price

                              }).ToList();

                return result;
            }
            else
            {
                return new List<BasketItemViewModel>();
            }
        }


       //gets our entire basket total as well as the summary of items in our basket. we do this by having nullable basket count items incase it is zero and baskettotal be nullable incase there is nothing.
       //if the basket is null we just return an empty model with 0 values.
        public BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext, false);
            BasketSummaryViewModel model = new BasketSummaryViewModel(0, 0);
            if (basket != null)
            {
                int? basketCount = (from item in basket.BasketItems
                                    select item.Quantity).Sum();


                decimal? basketTotal = (from item in basket.BasketItems
                                        join p in productContext.Collection() on item.ProductId equals p.ID
                                        select item.Quantity * p.Price).Sum();


                model.BasketCount = basketCount ?? 0;
                model.BasketTotal = basketTotal ?? decimal.Zero;

                return model;
            }
            else
            {
                return model;
            }
        }
    }
}

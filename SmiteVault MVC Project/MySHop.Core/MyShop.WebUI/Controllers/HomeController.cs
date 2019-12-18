using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;


        //dependency injects  Irepository<Product> productContext and Irepository<ProductCategory> productCategoryContext
        //into constructor.
        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }

        //setsup a product view and displays pertinent data on the product.
        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        //currently grabs index categories and has a base state if category is null. if there are no categories it jsut gets all items to a list. otherwise we get categories and products to a list.
        public ActionResult Index(string Category=null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if(Category == null)
            {
               products= context.Collection().ToList();
            }
            else
            {
               products = context.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;

            return View(model);
        }

        //these two items have been deprecated and unusued. left just because they are currently harmless and inaccessible.
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
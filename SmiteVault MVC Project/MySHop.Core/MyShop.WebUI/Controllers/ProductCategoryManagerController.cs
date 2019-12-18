using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        //All Views associated are named according to action and absed off scaffolding. Model Used: Prdouct(MyShop.Core.Models)
        //product repo

        IRepository<ProductCategory> context;

        //dependency injects Generic item from the Irepository<ProductCategory> into constructor.
        public ProductCategoryManagerController(IRepository<ProductCategory> Icontext)
        {
            this.context = Icontext;
        }

        //our index returns our View "Index" and displays all products from this controller.
        public ActionResult Index()
        {
            List<ProductCategory> productcategory = context.Collection().ToList();
            return View(productcategory);
        }

        //Create a new product 
        public ActionResult Create()
        {
            ProductCategory productcategory = new ProductCategory();
            return View(productcategory);
        }

        //our full cache post controller. This action result is linked to the View "Create"
        [HttpPost]
        public ActionResult Create(ProductCategory productcategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productcategory);
            }
            else
            {
                context.Insert(productcategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        //this is our edit base controller. we call this for single instance Id
        public ActionResult Edit(string Id)
        {
            ProductCategory productcategory = context.Find(Id);

            if (productcategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productcategory);
            }
        }


        //our post request if a product and Id are sent in. we update our View "Edit" using this controller.
        [HttpPost]
        public ActionResult Edit(ProductCategory productcategory, string Id)
        {
            ProductCategory productToEdit = context.Find(Id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productcategory);
                }
                productToEdit.Category = productcategory.Category;
               

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        //Delete base if we pass just id.
        public ActionResult Delete(string Id)
        {

            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }


        //Our Confirmation to Delete. we post and set the action name to delete on this. we then delete the item from cache and
        //commit. then we redirect to Index page. View "Delete"
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }

        }
    }
}
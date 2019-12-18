using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        //All Views associated are named according to action and absed off scaffolding. Model Used: Prdouct(MyShop.Core.Models)
        //product repo
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;


        //dependency injects  Irepository<Product> productContext and Irepository<ProductCategory> productCategoryContext
        //into constructor.
        public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory>  productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }

        //our index returns our View "Index" and displays all products from this controller.
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        //Create a new product 
        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            return View(viewModel);
        }

        //our full cache post controller. This action result is linked to the View "Create"
        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                //if the file is passed in from HttpPosteFileBase  we add the productId plus filename together to signify our image name.
                //we then save the image to productImages folder.
                if (file!= null)
                {
                    product.Image = product.ID + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                }
                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        //this is our edit base controller. we call this for single instance Id
        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();
                return View(viewModel);
            }
        }


        //our post request if a product and Id are sent in. we update our View "Edit" using this controller.
        [HttpPost]
        public ActionResult Edit(Product product, string Id, HttpPostedFileBase file)
        {
            Product productToEdit = context.Find(Id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                if(file!= null)
                {

                    productToEdit.Image = product.ID + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                    Console.WriteLine("made it to post file save");

                }
                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        
        //Delete base if we pass just id.
        public ActionResult Delete(string Id)
        {

            Product productToDelete = context.Find(Id);

            if (productToDelete== null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }


        //Our Confirmation to Delete. we post and set the action name to delete on this. we then delete the item from cache and
        //commit. then we redirect to Index page. View "Delete"
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
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
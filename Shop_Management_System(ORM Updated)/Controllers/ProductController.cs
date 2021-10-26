using Shop_Management_System_ORM_Updated_.Models.EF;
using Shop_Management_System_ORM_Updated_.Models.ViewModel;
using Shop_Management_System_ORM_Updated_.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shop_Management_System_ORM_Updated_.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult CustomerProduct()
        {
            List<ProductModel> prod = ProductRepository.GetAll();
            return View(prod);
        }

        [Authorize]
        public ActionResult AdminProduct()
        {
            List<ProductModel> prod = ProductRepository.GetAll();
            return View(prod);
        }

        public ActionResult AddtoCart(int Id)
        {
            ProductModel pm = new ProductModel();
            pm = ProductRepository.Get(Id);
            if(Session["cart"] == null)
            {
                List<ProductModel> products = new List<ProductModel>();
                products.Add(pm);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["cart"] = json;
                return RedirectToAction("CustomerProduct");
            }
            else
            {
                List<ProductModel> products = new List<ProductModel>();
                products = new JavaScriptSerializer().Deserialize<List<ProductModel>>((string)Session["cart"]);
                products.Add(pm);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["cart"] = json;
                return RedirectToAction("CustomerProduct");
            }    
        }

        public ActionResult Cart()
        {
            List<ProductModel> products = new List<ProductModel>();
            if(Session["cart"] == null)
            {
                return RedirectToAction("CustomerProduct");
            }
            products = new JavaScriptSerializer().Deserialize<List<ProductModel>>((string)Session["cart"]);
            return View(products);
        }

        public ActionResult DeleteCart(int Id)
        {
            List<ProductModel> products = new List<ProductModel>();
            products = new JavaScriptSerializer().Deserialize<List<ProductModel>>((string)Session["cart"]);
            var p = (from pr in products
                     where pr.Id == Id
                     select pr).FirstOrDefault();
            products.Remove(p);
            string json = new JavaScriptSerializer().Serialize(products);
            Session["cart"] = json;
            return RedirectToAction("Cart");
        }
    }
}
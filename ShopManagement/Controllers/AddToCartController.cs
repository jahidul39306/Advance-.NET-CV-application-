using ShopManagement.Models;
using ShopManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShopManagement.Controllers
{
    public class AddToCartController : Controller
    {
        // GET: AddToCart
        public ActionResult Cart()
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Product");
            }
            var cart = new JavaScriptSerializer().Deserialize<List<Product>>((string)Session["cart"]);
            return View(cart);
        }

        public ActionResult AddToCart(int Id)
        {
            if (Session["cart"] == null)
            {
                Product p = new Product();
                Database db = new Database();
                p = db.Products.Get(Id);
                List<Product> products = new List<Product>();
                products.Add(p);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["cart"] = json;
                return RedirectToAction("Index", "Product");
            }

            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>((string)Session["cart"]);
                Product p = new Product();
                Database db = new Database();
                p = db.Products.Get(Id);
                d.Add(p);
                string json = new JavaScriptSerializer().Serialize(d);
                Session["cart"] = json;
                return RedirectToAction("Index", "Product");
            }
        }

        /*        public ActionResult AddToCart(Product product)
                {
                    if (Session["cart"] == null)
                    {
                        List<Product> products = new List<Product>();
                        products.Add(product);
                        string json = new JavaScriptSerializer().Serialize(products);
                        Session["cart"] = json;
                        return RedirectToAction("Index");
                    }

                    else
                    {
                        var d = new JavaScriptSerializer().Deserialize<List<Product>>((string)Session["cart"]);
                        d.Add(product);
                        string json = new JavaScriptSerializer().Serialize(d);
                        Session["cart"] = json;
                        return RedirectToAction("Index");
                    }
                }*/


        public ActionResult CheckOut()
        {
            Database db = new Database();
            var cart = new JavaScriptSerializer().Deserialize<List<Product>>((string)Session["cart"]);
            foreach(var product in cart)
            {
                Order order = new Order()
                {
                    Product = product.Name,
                    Price = product.Price
                };
                db.Orders.Create(order);
            }
            Session["cart"] = null;
            return RedirectToAction("Index", "Product");
        }
    }
}
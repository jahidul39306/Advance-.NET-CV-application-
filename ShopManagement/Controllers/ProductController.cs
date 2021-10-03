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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Database db = new Database();
            var p = db.Products.Get();
            return View(p);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Product p = new Product();
            Database db = new Database();
            p = db.Products.Get(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Edit(p);
                return RedirectToAction("Index");
            }
            return View(p);
      
        }

        public ActionResult Delete(int Id)
        {
            Database db = new Database();
            db.Products.Delete(Id);
            return RedirectToAction("Index");
        }

        
    }
}
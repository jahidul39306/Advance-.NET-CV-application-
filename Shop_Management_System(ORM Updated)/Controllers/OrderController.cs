using Shop_Management_System_ORM_Updated_.Models.EF;
using Shop_Management_System_ORM_Updated_.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shop_Management_System_ORM_Updated_.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult CheckOut()
        {
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>((string)Session["cart"]);
            int CustomerId = int.Parse(HttpContext.User.Identity.Name.ToString());
            float totalPrice = 0;
            foreach(var p in products)
            {
                totalPrice = (float)p.Price + totalPrice;
            }
            var db = new ShopMSEntities();
            Order o = new Order()
            {
                FK_Customers_Id = CustomerId,
                Price = totalPrice,
                Status = "Ordered"
            };

            db.Orders.Add(o);
            db.SaveChanges();


            foreach (var p in products)
            {
                OrderDetail od = new OrderDetail()
                {
                    FK_Orders_Id = o.Id,
                    FK_Products_Id = p.Id,
                    Quantity = 1,
                    UnitPrice = p.Price    
                };

                db.OrderDetails.Add(od);
                db.SaveChanges();
            }
            Session.Remove("Cart");
            return RedirectToAction("CustomerProduct", "Product");
        }

        public ActionResult ShowOrders()
        {
            var db = new ShopMSEntities();
            int customerId = int.Parse(HttpContext.User.Identity.Name.ToString());
            var orders = (from o in db.Orders
                          where o.FK_Customers_Id == customerId
                          select o).ToList();

            List<OrderModel> om = new List<OrderModel>();
            foreach(var o in orders)
            {
                OrderModel ormo = new OrderModel()
                {
                    Id = o.Id,
                    Price = o.Price,
                    Status = o.Status
                };
                om.Add(ormo);
            }
            return View(om);
        }

        public ActionResult OrderDetail(int Id)
        {
            var db = new ShopMSEntities();
            var odetail = (from od in db.OrderDetails
                           where od.FK_Orders_Id == Id
                           select od).ToList();
            List<OrderDetailModel> odm = new List<OrderDetailModel>();
            foreach(var od in odetail)
            {
                OrderDetailModel o = new OrderDetailModel()
                {
                    FK_Orders_Id = od.FK_Orders_Id,
                    FK_Products_Id = od.FK_Products_Id,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                };
                odm.Add(o);
            }
            return View(odm);
        }
    }
}
using Shop_Management_System_ORM_Updated_.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop_Management_System_ORM_Updated_.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer c)
        {
            var db = new ShopMSEntities();
            var user = (from u in db.Customers
                        where u.Name == c.Name && u.Password == c.Password
                        select u).FirstOrDefault();
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                Session["UserType"] = "customer";
                return RedirectToAction("CustomerProduct", "Product");
            }

            var AdminUser = (from u in db.Admins
                             where u.Username == c.Name && u.Password == c.Password
                             select u).FirstOrDefault();
            if (AdminUser != null)
            {
                FormsAuthentication.SetAuthCookie(AdminUser.Id.ToString(), false);
                Session["UserType"] = "admin";
                return RedirectToAction("AdminProduct", "Product");
            }
            return View();
        }

/*        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var db = new ShopMSEntities();
            var AdminUser = (from u in db.Admins
                             where u.Username == a.Username && u.Password == a.Password
                             select u).FirstOrDefault();
            if (AdminUser != null)
            {
                FormsAuthentication.SetAuthCookie(AdminUser.Id.ToString(), true);
                Session["UserType"] = "admin";
                return RedirectToAction("AdminProduct", "Product");
            }
            return RedirectToAction("Login");
        }*/
    }
}
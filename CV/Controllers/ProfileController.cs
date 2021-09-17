using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Bio()
        {
            ViewBag.Name = "Jahidul Islam Noor";
            ViewBag.FatherName = "Shahajahan Mollh";
            ViewBag.MotherName = "Laila Begum";
            ViewBag.Dob = "01-sept-1999";
            ViewBag.Religion = "Islam";
            return View();
        }
        public ActionResult Education()
        {
            ViewBag.School = "Dhaka Collegiate School";
            ViewBag.SscResult = "5.0";

            ViewBag.College = "Dhaka City College";
            ViewBag.HscResult = "4.83";

            ViewBag.University = "AIUB";
            ViewBag.UniResult = "3.96";
            return View();
        }
        public ActionResult Projects()
        {
            ViewBag.Cpp = "Quiz game";
            ViewBag.Java = "Shop management system";

            ViewBag.Cs = "Universitty management system";
            ViewBag.WebTech = "Hospital management system";
            ViewBag.Python = "Snake game";

            return View();
        }
        public ActionResult References()
        {
            ViewData["ReferName"] = "Tanvir Ahmed";
            ViewData["ReferPos"] = "Assistant Professor";
            ViewData["ReferInst"] = "Department of CS, AIUB";
            return View();
        }
    }
}
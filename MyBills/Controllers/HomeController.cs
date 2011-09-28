using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Credits:
// From "Getting Started with MVC3" tutorial:
// http://www.asp.net/mvc/tutorials/getting-started-with-mvc3-part2-cs
//
namespace MyBills.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to myBills!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

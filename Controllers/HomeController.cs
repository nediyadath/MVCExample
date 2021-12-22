using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Product p = new Product();
            p.id = 101;
            p.name = "Oven";
            p.desc = "Microwave";

                return View(p);
        }

        public ActionResult FetchData()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles ="admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> plist = new List<Product>();
            Product p = new Product();
            p.id = 101;
            p.name = "Microwave Oven";
            p.desc = "40 ltr capacity";
            Product p1 = new Product();
            p1.id = 102;
            p1.name = "Fridge";
            p1.desc = "4000 ltr capacity";
            plist.Add(p);
            plist.Add(p1);

            return View(plist);
        }
    }
}
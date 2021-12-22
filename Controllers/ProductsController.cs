using MVCExample.DAL;
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
        CRUD cr = new CRUD();
        //ado dot net, Entity Framework code first, Entity framework database first
        // GET: Products
        public ActionResult Index()
        {
            return View(cr.FetchProducts());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p, FormCollection fc)
        {
            TempData["message"] = cr.InsertProduct(p);
            return RedirectToAction("index");
        }

    }
}
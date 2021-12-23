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
            string address = fc["txtAddress1"].ToString(); //
            string add = Request.Form["txtAddress2"].ToString();
            TempData["message"] = cr.InsertProduct(p);
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            Product p = cr.GetProduct(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            TempData["message"] = cr.EditProduct(p);
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            Product p = cr.GetProduct(id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            TempData["message"] = cr.DeleteRecord(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            Product p = cr.GetProduct(id);
            return View(p);
        }


    }
}
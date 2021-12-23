using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class DiscountController : Controller
    {
        CustomerContext db = new CustomerContext();
        // GET: Discount
        public ActionResult Index()
        {
            List<DiscountScheme> ds = db.discountScheme.ToList();
            return View(ds);
        }

        public ActionResult Create()
        {
            ViewBag.prodID = new SelectList(db.Products.ToList(), "id", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(DiscountScheme ds)
        {
            if (ModelState.IsValid)
            {
                db.discountScheme.Add(ds);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.prodID = new SelectList(db.Products.ToList(), "id", "name");
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(db.discountScheme.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(DiscountScheme ds)
        {
            db.Entry(ds).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            return View(db.discountScheme.Find(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            db.discountScheme.Remove(db.discountScheme.Find(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
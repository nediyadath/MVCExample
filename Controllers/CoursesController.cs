using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class CoursesController : Controller
    {
        CustomerContext cc = new CustomerContext();
        // GET: Courses
        public ActionResult ChooseCourse()
        {
            return View(cc.course.ToList());
        }

        [HttpPost]
        public ActionResult ChooseCourse(List<Course> courseList)
        {
            string choice = "";
            foreach(Course c in courseList)
            {
                if (c.check)
                {
                    choice += c.name + ',';
                }
            }
            choice = choice.TrimEnd(',');
            ViewBag.choice = choice;
            return View(cc.course.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            cc.course.Add(course);
            cc.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Index()
        {
            return View(cc.course.ToList());
        }
    }
}
using MyNoteMVC.Entity;
using MyNoteMVC.Models.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNoteMVC.Controllers
{
    public class CURDAJAXController : Controller
    {
        MydbEntities db = new MydbEntities();

        // GET: CURDAJAX
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult List()
        {
            var emp = db.Employees.ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Details(int id)
        {
            var emp = db.Employees.Find(id);
            return Json(emp, JsonRequestBehavior.AllowGet);
        }





        public JsonResult Create(EmployeeValidationClass emp)
        {
            if (ModelState.IsValid)
            {
                Employee em = new Employee();
                em.EName = emp.EName;
                em.EMobile = emp.EMobile;
                em.EEmail = emp.EEmail;
                em.Status = true;
                em.Createdate = System.DateTime.UtcNow;

                db.Employees.Add(em);
                db.SaveChanges();
                @TempData["Save"] = "Saved Successfully";
            }

            return Json(emp);
        }



        public ActionResult Edit(int id)
        {
            var emp = db.Employees.Find(id);

            if (emp != null)
            {
                EmployeeValidationClass em = new EmployeeValidationClass();
                em.EID = emp.EID;
                em.EName = emp.EName;
                em.EMobile = emp.EMobile;
                em.EEmail = emp.EEmail;
                return View(em);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EmployeeValidationClass emp)
        {
            if (ModelState.IsValid)
            {
                Employee em = new Employee();
                em.EID = emp.EID;
                em.EName = emp.EName;
                em.EMobile = emp.EMobile;
                em.EEmail = emp.EEmail;
                em.Status = true;
                em.Updatedate = System.DateTime.UtcNow;

                db.Entry(em).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(emp);
        }



        public ActionResult Delete(int id)
        {
            var emp = db.Employees.Find(id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                @TempData["Delete"] = "Delete Successfully";
                //return RedirectToAction("List");
            }
            return View(emp);
        }




        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}


    }
}
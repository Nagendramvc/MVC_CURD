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

   [RoutePrefix("Employee")]
    public class CURDEFController : Controller
    {
        MydbEntities db = new MydbEntities();

        // GET: CURDEF
        public ActionResult Index()
        {
            return View();
        }

        //Employee List
        [Route("MvcList")]
        public ActionResult List()
        {
           var emp = db.Employees.ToList();
            return View(emp);
        }

        //Employee Details
        public ActionResult Details(int id)
        {
            var emp = db.Employees.Find(id);
            return View(emp);
        }


        //Create Employee
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeValidationClass emp)
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

                TempData["Save"] = "Saved Successfully";
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("", "Please fill all fileds");
                return View(emp);
            }

           
        }


        //Edit Employee
        public ActionResult Edit(int id)
        {
            var emp = db.Employees.Find(id);

            if(emp!=null)
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
                Employee em = db.Employees.Find(emp.EID);
                em.EID = emp.EID;
                em.EName = emp.EName;
                em.EMobile = emp.EMobile;
                em.EEmail = emp.EEmail;
                em.Status = true;
                em.Updatedate = System.DateTime.UtcNow;

                db.Entry(em).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Edit"] = "Update Successfully";
                return RedirectToAction("List");
            }

            return View(emp);
        }


        //Delete Employee
        public ActionResult Delete(int id)
        {
            var emp = db.Employees.Find(id);
            if(emp!=null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();

                TempData["Delete"] = "Delete Successfully";
                return RedirectToAction("List");
            }
            return View(emp);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



    }
}
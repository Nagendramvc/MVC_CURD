using MyNoteMVC.Entity;
using MyNoteMVC.Models.Factory;
using MyNoteMVC.Models.Modelclasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNoteMVC.Controllers
{
    public class CURDQUERYFactoryController : Controller
    {
        // GET: CURDQUERYFactory
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            List<TbEmployee> lst = new List<TbEmployee>();

            EmployeeQueryfactory resp = new EmployeeQueryfactory();
            var dt = resp.GetAllEmployee();
            return View(dt);

            //foreach (DataRow row in dt.Rows)
            //{
            //    lst.Add(new TbEmployee
            //    {
            //        EID = Convert.ToInt32(row["Id"]),
            //        Name = row["Name"].ToString(),
            //        Age = Convert.ToInt32(row["Age"]),
            //        Gender = row["Gender"].ToString()
            //    });
            //}

           // return View(lst);
        }


        //Details
        public ActionResult Details(int EID)
        {
            EmployeeQueryfactory resp = new EmployeeQueryfactory();
            var obj = resp.GetEmployeeByID(EID);

            return View();
        }


        //Delete
        public ActionResult delete(int EID)
        {
            EmployeeQueryfactory resp = new EmployeeQueryfactory();
            var obj = resp.DeleteEmployee(EID);

            return RedirectToAction("List");
        }



        //Edit
        public ActionResult Edit(int id)
        {
            return View();
        }



        public ActionResult Edit()
        {
            return View();
        }


        //Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(FormCollection frm, string action, TbEmployee emp)
        {
            if (action == "Submit")
            {
                EmployeeQueryfactory resp = new EmployeeQueryfactory();

                string Name = frm["txtName"];
                int Age = Convert.ToInt32(frm["txtAge"]);
                string Gender = frm["gender"];

                int status = resp.InsertEmployee(emp);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }





    }
}
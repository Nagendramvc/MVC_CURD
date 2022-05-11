using MyNoteMVC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNoteMVC.Controllers
{
    public class TaskController : Controller
    {
        MydbEntities db = new MydbEntities();

        // GET: Task
        public ActionResult Index()
        {
            return View();
        }



        //Get List data
        public ActionResult Rolelist()
        {
            var myList = db.UserRoles.ToList();

            return View(myList);
        }






        /// <summary>
        /// Get List data convert into single row with comma(,)
        /// </summary>
        /// <returns>//prints: "foo,bar,baz"</returns>
        public ActionResult SingleRowRoles()
        {
            //var myList = new List<String> { "foo", "bar", "baz" };
            var myList = db.UserRoles.ToList();

            string output = String.Join(",", myList); //prints: "foo,bar,baz"

            return View(output);
        }









        //Save data separte comma and save muti-rows
        public ActionResult SavemultiRowRoles()
        {


            return View();
        }


        [HttpPost]
        public ActionResult RoleUpdate(string role)
        {
            //String
            string combinedString = string.Join(",", role);

            //List
            string listobj = string.Join(",", role.ToArray());

            //var obj = db.UserRoles.ToList();


            if (role!= null)
            {
               return RedirectToAction("");
            }
            else
            {

            }

            return View();
        }































    }
}
using MyNoteMVC.Entity;
using MyNoteMVC.Models.User;
using MyNoteMVC.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNoteMVC.Controllers
{
    //Controller
    public class UserinfoController : Controller
    {
        MydbEntities db = new MydbEntities();

        // GET: Userinfo
        public ActionResult Index()
        {
            return View();
        }


            //Action Method
            [ActionName("Log")]
            public ActionResult Login()
            {
                return View();
            }


            [HttpPost] 
            public ActionResult Login(UserLogin usr)
            {
            if(ModelState.IsValid)
            {
                var uss = db.Userinfoes.Where(a => a.Email == usr.Username && a.Password == usr.Password).FirstOrDefault();
                if (uss != null)
                {
                    Session["Email"] = uss.Email;
                }
                else
                {
                    var ues = db.Userinfoes.Where(a => a.Mobile == usr.Username && a.Password == usr.Password).FirstOrDefault();
                    Session["Email"] = ues.Email;
                }
                RedirectToAction("Dashboard");
            }
            else
            {

            }
            return View(usr);
        }





        public ActionResult Dashboard()
        {
            string username = Session["Email"].ToString();
            return View();
        }




        public ActionResult RegistrationList()
        {
            var usr = db.Userinfoes.ToList();
            return View(usr);
        }


        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registration(UserRegistrationValidationClass usr)
        {
            if(ModelState.IsValid)
            {
                Userinfo info = new Userinfo();
                info.Name = usr.Name;
                info.Mobile = usr.Mobile;
                info.Email = usr.Email;
                info.Password = usr.Password;
                db.Userinfoes.Add(info);
                db.SaveChanges();
                return RedirectToAction("RegistrationList");
            }
          
           return View();
        }



















    }
}
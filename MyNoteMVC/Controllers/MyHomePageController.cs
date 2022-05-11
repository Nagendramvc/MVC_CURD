using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNoteMVC.Controllers
{
    public class MyHomePageController : Controller
    {
        // GET: MyHomePage
        public ActionResult Index()
        {
            return View();
        }
    }
}
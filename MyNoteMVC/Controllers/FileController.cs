using MyNoteMVC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNoteMVC.Controllers
{
    public class FileController : Controller
    {

        //https://www.c-sharpcorner.com/UploadFile/sourabh_mishra1/fileupload-in-Asp-Net-mvc/


        //DB Connection
        MydbEntities db = new MydbEntities();


        // GET: File
        public ActionResult Index()
        {
            return View();
        }



        //Upload file
        public ActionResult Uploadfile()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file_Uploader)
        {
            return View();
        }




            //Multi Upload file
            public ActionResult Multiuploadfile()
        {
            return View();
        }




        //Download file
        public ActionResult Downloadfile()
        {
            return View();
        }



        //Download file with zip
        public ActionResult FileDownloadwithzip()
        {
            return View();
        }

















        // Upload photo/Image
        public ActionResult Uploadphoto()
        {
            return View();
        }






        //[HttpPost]
        //public ActionResult RemoveUploadFile(string fileName)
        //{
        //    int sessionFileCount = 0;
        //    try
        //    {
        //        if (Session["fileUploader"] != null)
        //        {
        //            ((List<FileUploadModel>)Session["fileUploader"]).RemoveAll(x => x.FileName == fileName);
        //            sessionFileCount = ((List<FileUploadModel>)Session["fileUploader"]).Count;
        //            if (fileName != null || fileName != string.Empty)
        //            {
        //                FileInfo file = new FileInfo(Server.MapPath("~/MyFiles/" + fileName));
        //                if (file.Exists)
        //                {
        //                    file.Delete();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Json(sessionFileCount, JsonRequestBehavior.AllowGet);
        //}  
















    }
}
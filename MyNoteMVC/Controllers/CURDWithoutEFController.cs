using MyNoteMVC.Entity;
using MyNoteMVC.Models.Validation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNoteMVC.Controllers
{
    public class CURDWithoutEFController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;

        // GET: CURDWithoutEF
        public ActionResult Index()
        {
            return View();
        }

        //Get Employee List
        public ActionResult List()
        {
            List<Employee> lst = new List<Employee>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_EmployeeList", con);
                com.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Employee
                    {
                        EID = Convert.ToInt32(rdr["EID"]),
                        EName = rdr["EName"].ToString(),
                        EMobile = rdr["EMobile"].ToString(),
                        EEmail = rdr["EEmail"].ToString(),
                    });
                }
            }

            return View(lst);
        }


        //Get Employee Details
        public ActionResult Details(int id)
        {
            Employee lst = new Employee();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_EmployeeDetail", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@EID", id);

                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.EID = Convert.ToInt32(rdr["EID"]);
                    lst.EName = rdr["EName"].ToString();
                    lst.EMobile = rdr["EMobile"].ToString();
                    lst.EEmail = rdr["EEmail"].ToString();
                }
            }

            return View(lst);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeValidationClass emp)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SP_Insertupdateemployee", con);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@EID", emp.EID);
                    com.Parameters.AddWithValue("@EName", emp.EName);
                    com.Parameters.AddWithValue("@EEmail", emp.EEmail);
                    com.Parameters.AddWithValue("@EMobile", emp.EMobile);
                    com.Parameters.AddWithValue("@Action", "Insert");
                    com.ExecuteNonQuery();
                }
                return RedirectToAction("List");
            }
            else
            {

            }

           return View(emp);
        }


        public ActionResult Edit(int id)
        {
            EmployeeValidationClass lst = new EmployeeValidationClass();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_EmployeeDetail", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@EID", id);

                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.EID = Convert.ToInt32(rdr["EID"]);
                    lst.EName = rdr["EName"].ToString();
                    lst.EMobile = rdr["EMobile"].ToString();
                    lst.EEmail = rdr["EEmail"].ToString();
                }
            }

           return View(lst);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeValidationClass emp)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SP_Insertupdateemployee", con);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@EID", emp.EID);
                    com.Parameters.AddWithValue("@EName", emp.EName);
                    com.Parameters.AddWithValue("@EEmail", emp.EEmail);
                    com.Parameters.AddWithValue("@EMobile", emp.EMobile);
                    com.Parameters.AddWithValue("@Action", "Update");
                    com.ExecuteNonQuery();
                }
                return RedirectToAction("List");
            }
            else
            {

            }

            return View(emp);
        }



        //Deleting an Employee
        public ActionResult Delete(int id)
        {
            if(id!=0)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SP_DeleteEmployee", con);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@EID", id);
                    com.ExecuteNonQuery();
                }
                return RedirectToAction("List");
            }
            else
            {

            }
            return View();
        }








    }
}
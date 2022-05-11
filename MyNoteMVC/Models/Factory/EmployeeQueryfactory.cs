using MyNoteMVC.Entity;
using MyNoteMVC.Models.Modelclasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyNoteMVC.Models.Factory
{
    public class EmployeeQueryfactory
    {

        /// <summary>
        /// Get Employee List
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllEmployee()
        {
            string strConString = @"Data Source=DES-W10-LAP18;Initial Catalog=Mydb;Integrated Security=True";

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from TbEmployee", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


        /// <summary>
        /// Get Employee details
        /// </summary>
        /// <param name="intStudentID = EID"></param>
        /// <returns></returns>
        public DataTable GetEmployeeByID(int EID)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=DES-W10-LAP18;Initial Catalog=Mydb;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from TbEmployee where EID=" + EID, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }



        /// <summary>
        /// Update Employee details into database
        /// </summary>
        /// <param name="intStudentID"></param>
        /// <param name="strStudentName"></param>
        /// <param name="strGender"></param>
        /// <param name="intAge"></param>
        /// <returns></returns>
        public int UpdateEmployee(TbEmployee emp)
        {
            string strConString = @"Data Source=DES-W10-LAP18;Initial Catalog=Mydb;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Update TbEmployee SET Name=@Name, Age=@Age, Gender=@Gender where EID=@EID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@EID", emp.EID);
                return cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Insert Employee
        /// </summary>
        /// <param name="strStudentName"></param>
        /// <param name="strGender"></param>
        /// <param name="intAge"></param>
        /// <returns></returns>
        public int InsertEmployee(TbEmployee emp)
        {
            string strConString = @"Data Source=DES-W10-LAP18;Initial Catalog=Mydb;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into TbEmployee (Name, Age,Gender) values(@Name, @Age , @Gender)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                return cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="EID"></param>
        /// <returns></returns>
        public int DeleteEmployee(int EID)
        {
            string strConString = @"Data Source=DES-W10-LAP18;Initial Catalog=Mydb;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from Employee where EID=@EID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EID", EID);
                return cmd.ExecuteNonQuery();
            }
        }






    }
}
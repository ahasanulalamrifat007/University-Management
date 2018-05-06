using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.DAL
{
    public class EnrollcdGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public List<Enrollcd> GetAllCourseAndDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM cds";
            SqlCommand command = new SqlCommand(query, connection);
            List<Enrollcd> aList = new List<Enrollcd>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Enrollcd aEnrollcd = new Enrollcd();
                    aEnrollcd.RegistrationNo = reader["RegistrationNo"].ToString();
                    aEnrollcd.StudentName = reader["StudentName"].ToString();
                    aEnrollcd.Email = reader["Email"].ToString();
                    aEnrollcd.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                    aEnrollcd.DepartmentCode = reader["DepartmentCode"].ToString();
                    aEnrollcd.DepartmentName = reader["DepartmentName"].ToString();
                    aEnrollcd.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    aEnrollcd.CourseCode = reader["CourseCode"].ToString();
                    aEnrollcd.CourseName = reader["CourseName"].ToString();
                    aList.Add(aEnrollcd);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }


        public int GetDepartmentIdByRegNo(string RegNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT DepartmentId FROM cds where RegistrationNo='" + RegNo + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int x =0;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    x = Convert.ToInt32(reader["DepartmentId"].ToString());

                }
                reader.Close();
            }
            connection.Close();
            return x;
        }
    }
}
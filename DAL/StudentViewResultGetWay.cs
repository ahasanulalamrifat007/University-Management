using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class StudentViewResultGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public List<StudentViewResult> GetViewResult(string RegNo)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "SELECT * FROM viewresult WHERE Status='1'";
            SqlCommand command=new SqlCommand(query,connection);
            List<StudentViewResult>alist=new List<StudentViewResult>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    StudentViewResult aStudentViewResult=new StudentViewResult();
                    aStudentViewResult.RegistrationNo = reader["RegistrationNo"].ToString();
                    aStudentViewResult.Name = reader["Name"].ToString();
                    aStudentViewResult.Email = reader["Email"].ToString();
                    aStudentViewResult.DepartmentName = reader["DepartmentName"].ToString();
                    aStudentViewResult.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    aStudentViewResult.CourseCode = reader["CourseCode"].ToString();
                    aStudentViewResult.CourseName = reader["CourseName"].ToString();
                    aStudentViewResult.Grade = reader["Grade"].ToString();
                    alist.Add(aStudentViewResult);
                }
                reader.Close();
            }
            connection.Close();
            return alist;
        }
    }
}
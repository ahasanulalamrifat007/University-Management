using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.DAL
{
    public class SCDGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;


        public List<SCD> GetStudentInfoWithDepartmentNameAndCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM SCDx1x2";
            SqlCommand command = new SqlCommand(query, connection);
            List<SCD> aList = new List<SCD>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SCD aScd = new SCD();
                    aScd.RegistrationNo = reader["RegistrationNo"].ToString();
                    aScd.Name = reader["Name"].ToString();
                    aScd.Email = reader["Email"].ToString();
                    aScd.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    aScd.CourseCode = reader["CourseCode"].ToString();
                    aScd.CourseName = reader["CourseName"].ToString();
                    aList.Add(aScd);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }


        public List<SCD> GetStudentInfoWithDepartmentNameAndCourseTrue()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM SCDx1x2 Where  Status = '1' ";
            SqlCommand command = new SqlCommand(query, connection);
            List<SCD> aList = new List<SCD>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SCD aScd = new SCD();
                    aScd.RegistrationNo = reader["RegistrationNo"].ToString();
                    aScd.Name = reader["Name"].ToString();
                    aScd.Email = reader["Email"].ToString();
                    aScd.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    aScd.CourseCode = reader["CourseCode"].ToString();
                    aScd.CourseName = reader["CourseName"].ToString();
                    aList.Add(aScd);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }
    }

}
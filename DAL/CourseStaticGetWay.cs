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
    public class CourseStaticGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public List<CourseStatics> GetAllCourseStaticses()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM v_dogcat";
            SqlCommand command = new SqlCommand(query, connection);
            List<CourseStatics> aList = new List<CourseStatics>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CourseStatics aCourseStatics=new CourseStatics();
                    aCourseStatics.CourseCode =     reader["CourseCode"].ToString();
                    aCourseStatics.CourseName =     reader["CourseName"].ToString();
                    aCourseStatics.SemesterName =   reader["Semester"].ToString();
                    aCourseStatics.DepartmentId =   Convert.ToInt32(reader["DepartmentId"].ToString());
                    aCourseStatics.TeacherName =    reader["TeacherName"].ToString();
                    aList.Add(aCourseStatics);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }

        public List<CourseStatics> GetAllCourseStaticsesbyDepartmentId(int a)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM v_dogcat WHERE DepartmentId='" + a + "'";
            SqlCommand command = new SqlCommand(query, connection);
            List<CourseStatics> aList = new List<CourseStatics>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CourseStatics aCourseStatics = new CourseStatics();
                    aCourseStatics.CourseCode = reader["CourseCode"].ToString();
                    aCourseStatics.CourseName = reader["CourseName"].ToString();
                    aCourseStatics.SemesterName = reader["Semester"].ToString();
                    aCourseStatics.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                    aCourseStatics.TeacherName = reader["TeacherName"].ToString();
                    aCourseStatics.Status = reader["Status"].ToString();
                    aList.Add(aCourseStatics);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }
    }
}
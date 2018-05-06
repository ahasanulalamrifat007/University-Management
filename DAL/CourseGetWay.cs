using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class CourseGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public int SaveCourse(Course aCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_course (Code,Name,Credit,Description,DepartmentId,SemesterId) " +
                           "VALUES (@Code,@Name,@Credit,@Description,@DepartmentId,@SemesterId)";
            SqlCommand command = new SqlCommand(query, connection);
            if (aCourse.Description == null)
            {
                aCourse.Description = "Empty";
            }
            command.Parameters.Clear();
            command.Parameters.Add("@Code", SqlDbType.VarChar);
            command.Parameters["@Code"].Value = aCourse.Code;
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = aCourse.Name;
            command.Parameters.Add("@Credit", SqlDbType.Float);
            command.Parameters["@Credit"].Value = aCourse.Credit;
            command.Parameters.Add("@Description", SqlDbType.VarChar);
            command.Parameters["@Description"].Value = aCourse.Description;
            command.Parameters.Add("@DepartmentId", SqlDbType.Int);
            command.Parameters["@DepartmentId"].Value = aCourse.DepartmentId;
            command.Parameters.Add("@SemesterId", SqlDbType.Int);
            command.Parameters["@SemesterId"].Value = aCourse.SemesterId;

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }


        public List<Course> GetAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_course";
            SqlCommand command = new SqlCommand(query, connection);
            List<Course> aList = new List<Course>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course aCourseClass = new Course();
                    aCourseClass.Id = Convert.ToInt32(reader["Id"].ToString());
                    aCourseClass.Code = reader["Code"].ToString();
                    aCourseClass.Name = reader["Name"].ToString();
                    aCourseClass.Credit = Convert.ToDouble(reader["Credit"].ToString());
                    aCourseClass.Description = reader["Description"].ToString();
                    aCourseClass.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                    aCourseClass.SemesterId = Convert.ToInt32(reader["SemesterId"].ToString());
                    aList.Add(aCourseClass);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }

    }
}
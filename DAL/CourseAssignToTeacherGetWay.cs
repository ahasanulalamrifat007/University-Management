using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class CourseAssignToTeacherGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public int AssignCourseToTeacher(CourseAssignToTeacher assign)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_courseassingtoteacher (TeacherId,CourseId,Status) VALUES('" + assign.TeacherId + "','" + assign.CourseId + "','1')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<CourseAssignToTeacher> GetAllCourseassinAssignToTeachers()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_courseassingtoteacher";
            SqlCommand command = new SqlCommand(query, connection);
            List<CourseAssignToTeacher> aList = new List<CourseAssignToTeacher>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CourseAssignToTeacher assignToTeacher = new CourseAssignToTeacher();
                    assignToTeacher.TeacherId = Convert.ToInt32(reader["TeacherId"].ToString());
                    assignToTeacher.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    assignToTeacher.Status = Convert.ToBoolean(reader["Status"].ToString());
                    aList.Add(assignToTeacher);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }


        //Status True
        public List<CourseAssignToTeacher> GetAllCourseassinAssignToTeachersTrue()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_courseassingtoteacher WHERE Status='1'";
            SqlCommand command = new SqlCommand(query, connection);
            List<CourseAssignToTeacher> aList = new List<CourseAssignToTeacher>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CourseAssignToTeacher assignToTeacher = new CourseAssignToTeacher();
                    assignToTeacher.TeacherId = Convert.ToInt32(reader["TeacherId"].ToString());
                    assignToTeacher.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    assignToTeacher.Status = Convert.ToBoolean(reader["Status"].ToString());
                    aList.Add(assignToTeacher);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }
        //Status False
        public List<CourseAssignToTeacher> GetAllCourseassinAssignToTeachersFalse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_courseassingtoteacher WHERE Status='0'";
            SqlCommand command = new SqlCommand(query, connection);
            List<CourseAssignToTeacher> aList = new List<CourseAssignToTeacher>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CourseAssignToTeacher assignToTeacher = new CourseAssignToTeacher();
                    assignToTeacher.TeacherId = Convert.ToInt32(reader["TeacherId"].ToString());
                    assignToTeacher.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    assignToTeacher.Status = Convert.ToBoolean(reader["Status"].ToString());
                    aList.Add(assignToTeacher);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }
        //Update
        public int UpdateAssignCourse(CourseAssignToTeacher assign)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Update t_courseassingtoteacher Set TeacherId = '" + assign.TeacherId + "',Status = '1' WHERE (CourseId = '" + assign.CourseId +"')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public void UpdateRemainingCredit(double credit,int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE  t_teacher SET RemainingCredit-='" + credit + "' WHERE Id='"+id+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

    }
}
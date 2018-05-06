using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class EnrollGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public int EnrollCourse(Enroll aEnroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO enrollcourse (RegistrationNo,CorseId,Date,Status) VALUES('" + aEnroll.StudentRegNo + "','" + aEnroll.CourseId + "','" + aEnroll.Date + "','1')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<Enroll> GetAllEnrollsByRegNo(String RegNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM enrollcourse WHERE RegistrationNo='"+RegNo+"'";
            SqlCommand command=new SqlCommand(query,connection);
            List<Enroll> list=new List<Enroll>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Enroll aEnroll=new Enroll();
                    aEnroll.StudentRegNo = reader["RegistrationNo"].ToString();
                    aEnroll.CourseId = Convert.ToInt32(reader["CorseId"].ToString());
                    aEnroll.Date = Convert.ToDateTime(reader["Date"].ToString());
                    aEnroll.Status = Convert.ToBoolean(reader["Status"].ToString());
                    list.Add(aEnroll);
                }
                reader.Close();
            }
            connection.Close();
            return list;
        }

        //Status True
        public List<Enroll> GetAllEnrollsByRegNoTrue(String RegNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM enrollcourse WHERE RegistrationNo='" + RegNo + "' and Status = '1' ";
            SqlCommand command = new SqlCommand(query, connection);
            List<Enroll> list = new List<Enroll>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Enroll aEnroll = new Enroll();
                    aEnroll.StudentRegNo = reader["RegistrationNo"].ToString();
                    aEnroll.CourseId = Convert.ToInt32(reader["CorseId"].ToString());
                    aEnroll.Date = Convert.ToDateTime(reader["Date"].ToString());
                    aEnroll.Status = Convert.ToBoolean(reader["Status"].ToString());
                    list.Add(aEnroll);
                }
                reader.Close();
            }
            connection.Close();
            return list;
        }
    }
}
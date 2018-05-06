using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class StudentResultGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public int SaveStudentResult(StudentResult aStudentResult)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "Insert Into t_studentresult (RegistrationNo,Name,Email,DepartmentName,CourseId,MidNum,QuizeNum,AsignmentNum,Attendence,FinalNum,Grade) " +
                           "VALUES ('" + aStudentResult.RegistrationNo + "','" + aStudentResult.Name + "','" + aStudentResult.Email+"','" + aStudentResult.DepartmentName+"','" + aStudentResult.CourseId + "','" + aStudentResult.MidNum + "','" + aStudentResult.QuizeNum+ "','"+ aStudentResult.AsignmentNum+ "','"+ aStudentResult.FinalNum + "','" + aStudentResult.Grade+"')";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            int rowsAffected=command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<StudentResult> GetAllStudentResultsByRegNo(string RegNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_studentresult WHERE RegistrationNo='" + RegNo + "'";
            SqlCommand command = new SqlCommand(query, connection);
            List<StudentResult> list = new List<StudentResult>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StudentResult aResult = new StudentResult();
                    aResult.RegistrationNo = reader["RegistrationNo"].ToString();
                    aResult.Name = reader["Name"].ToString();
                    aResult.Email = reader["Email"].ToString();
                    aResult.DepartmentName = reader["DepartmentName"].ToString();
                    aResult.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    aResult.MidNum = Convert.ToInt32(reader["MidNum"].ToString());
                    aResult.QuizeNum = Convert.ToInt32(reader["QuizeNum"].ToString());
                    aResult.AsignmentNum = Convert.ToInt32(reader["AsignmentNum"].ToString());
                    aResult.Attendence = Convert.ToInt32(reader["Attendence"].ToString());
                    aResult.FinalNum = Convert.ToInt32(reader["FinalNum"].ToString());
                    aResult.Grade = reader["Grade"].ToString();
                    list.Add(aResult);
                }
                reader.Close();
            }
            connection.Close();
            return list;
        }
    }
}
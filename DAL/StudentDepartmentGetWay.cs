using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.DAL
{
    public class StudentDepartmentGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public List<StudentDepartment> GetStudentInfoWithDepartmentName()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM student_department";
            SqlCommand command = new SqlCommand(query, connection);
            List<StudentDepartment> aList = new List<StudentDepartment>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StudentDepartment aStudentDepartment = new StudentDepartment();
                    aStudentDepartment.RegistrationNo = reader["RegistrationNo"].ToString();
                    aStudentDepartment.Name = reader["Name"].ToString();
                    aStudentDepartment.Email = reader["Email"].ToString();
                    aStudentDepartment.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                    aStudentDepartment.DepartmentCode = reader["DepartmentCode"].ToString();
                    aStudentDepartment.DepartmentName = reader["DepartmentName"].ToString();
                    aList.Add(aStudentDepartment);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }
    }
}
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
    public class StudentGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public int SaveStudent(Student aStudent)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_student (RegistrationNo,Name,Email,ContactNo,Date,Address,DepartmentId) " +
                           "Values (@RegistrationNo,@Name,@Email,@ContactNo,@Date,@Address,@DepartmentId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@RegistrationNo", SqlDbType.VarChar);
            command.Parameters["@RegistrationNo"].Value =aStudent.RegistrarionNo;
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = aStudent.Name;
            command.Parameters.Add("@Email", SqlDbType.VarChar);
            command.Parameters["@Email"].Value = aStudent.Email;
            command.Parameters.Add("@ContactNo", SqlDbType.VarChar);
            command.Parameters["@ContactNo"].Value = aStudent.ContactNo;
            command.Parameters.Add("@Date", SqlDbType.Date);
            command.Parameters["@Date"].Value = aStudent.Date;
            command.Parameters.Add("@Address", SqlDbType.VarChar);
            command.Parameters["@Address"].Value = aStudent.Address;
            command.Parameters.Add("@DepartmentId", SqlDbType.Int);
            command.Parameters["@DepartmentId"].Value = aStudent.DepartmentId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<Student> GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_student";
            List<Student>list=new List<Student>();
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student aStudent=new Student();
                    aStudent.RegistrarionNo = reader["RegistrationNo"].ToString();
                    aStudent.Name = reader["Name"].ToString();
                    aStudent.Email = reader["Email"].ToString();
                    aStudent.ContactNo = reader["ContactNo"].ToString();
                    aStudent.Address = reader["Address"].ToString();
                    aStudent.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                    aStudent.Date = Convert.ToDateTime(reader["Date"].ToString());
                    list.Add(aStudent);
                }
                reader.Close();
            }
            connection.Close();
            return list;
        }

        public string GetDepartmentCodeById(int departmentid)
        {
            string departmentcode = "";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Code FROM t_department WHERE Id='" + departmentid + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                departmentcode = reader["Code"].ToString();
            }
            reader.Close();
            connection.Close();
            return departmentcode;
        }

        public List<Student> GetRegistrationNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT RegistrarionNo FROM t_student";
            List<Student> list = new List<Student>();
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student aStudent = new Student();
                    aStudent.Name = reader["Name"].ToString();
                    aStudent.Email = reader["Email"].ToString();
                    aStudent.ContactNo = reader["ContactNo"].ToString();
                    aStudent.Address = reader["Address"].ToString();
                    aStudent.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                    aStudent.Date = Convert.ToDateTime(reader["Date"].ToString());
                    list.Add(aStudent);
                }
                reader.Close();
            }
            connection.Close();
            return list;
        }

        public int NoOfRegistraion()
        {
            int totalregno=0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT count(*) as data FROM t_student";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader=command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    totalregno = Convert.ToInt32(reader["data"].ToString());
                }
                reader.Close();
            }
            connection.Close();
            return totalregno;
        }

        public int NoOfCodeAndYear(int number, string codeyear)
        {
            int totalcyno =0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select count(*) as rdata from t_student where left(RegistrationNo,'" + number + "')='"+codeyear+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    totalcyno = Convert.ToInt32(reader["rdata"].ToString());
                }
                reader.Close();
            }
            connection.Close();
            return totalcyno;
        }
    }
}
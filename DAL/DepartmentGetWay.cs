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
    public class DepartmentGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public int SaveDepartment(Department aDepartmentClass)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_department (Code,Name) VALUES(@Code,@Name)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Code", SqlDbType.VarChar);
            command.Parameters["@Code"].Value = aDepartmentClass.Code;

            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = aDepartmentClass.Name;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<Department> GetAllDepartmentInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_department";
            SqlCommand command = new SqlCommand(query, connection);
            List<Department> aList = new List<Department>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department aDepartment = new Department();
                    aDepartment.Id = Convert.ToInt32(reader["Id"].ToString());
                    aDepartment.Code = reader["Code"].ToString();
                    aDepartment.Name = reader["Name"].ToString();
                    aList.Add(aDepartment);
                }
            }
            return aList;
        }
        
    }
}
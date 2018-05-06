using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class SemesterGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public List<Semester> GetAllSemester()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_semester";
            SqlCommand command = new SqlCommand(query, connection);
            List<Semester> aList = new List<Semester>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Semester aSemesterClass = new Semester();
                    aSemesterClass.Id = Convert.ToInt32(reader["Id"].ToString());
                    aSemesterClass.Name = reader["Name"].ToString();
                    aList.Add(aSemesterClass);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }
    }
}
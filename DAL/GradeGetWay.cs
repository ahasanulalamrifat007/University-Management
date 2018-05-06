using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class GradeGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public List<Grade> GetAllGrades()
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "SELECT * FROM t_grade";
            SqlCommand command=new SqlCommand(query,connection);
            List<Grade>alist=new List<Grade>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Grade aGrade=new Grade();
                    aGrade.Id = Convert.ToInt32(reader["Id"].ToString());
                    aGrade.Grades = reader["Grade"].ToString();
                    alist.Add(aGrade);
                }
                reader.Close();
            }
            connection.Close();
            return alist;
        }
    }
}
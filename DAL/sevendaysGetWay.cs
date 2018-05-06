using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class sevendaysGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public List<sevendays> GetAllDays()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * from t_day";
            SqlCommand command = new SqlCommand(query, connection);
            List<sevendays> aList = new List<sevendays>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sevendays aSevendays = new sevendays();
                    aSevendays.Id = Convert.ToInt32(reader["Id"].ToString());
                    aSevendays.Days = reader["Day"].ToString();
                    aList.Add(aSevendays);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementSystemMVC.DAL
{
    public class UnassignGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public void UnassignCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE enrollcourse SET Status='0' Where Status='1'";
            string tquery = "UPDATE t_courseassingtoteacher SET Status='0' Where Status='1'";

            SqlCommand command = new SqlCommand(query, connection);
            SqlCommand tcommand = new SqlCommand(tquery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            tcommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
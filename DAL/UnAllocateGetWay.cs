using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementSystemMVC.DAL
{
    public class UnAllocateGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public void UnAllocateRooms()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE t_allocateclassroom SET Status='0' Where Status='1'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
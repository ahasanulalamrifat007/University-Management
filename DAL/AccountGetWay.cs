using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.DAL
{
    public class AccountGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;
        public User CheckLogin(UserViewModel user)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_users where Username='"+user.Username+"' and Password='"+user.Password+"';";
            SqlCommand command = new SqlCommand(query, connection);
            User hasUser=new User();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hasUser.Id = Convert.ToInt32(reader["Id"].ToString());
                    hasUser.Username = reader["Username"].ToString();
                    hasUser.Password = reader["Password"].ToString();
                    hasUser.Role = reader["Role"].ToString();
                }
            }
            return hasUser;
        }
    }
}
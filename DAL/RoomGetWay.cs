using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class RoomGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public List<Room> GetAllRooms()
        {
            SqlConnection connection=new SqlConnection(connectionString);
            List<Room>alist=new List<Room>();
            string query = "SELECT * FROM t_room";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Room aRoom=new Room();
                    aRoom.Id = Convert.ToInt32(reader["Id"].ToString());
                    aRoom.RoomNo = reader["RoomNo"].ToString();
                    alist.Add(aRoom);
                }
                reader.Close();
            }
            connection.Close();
            return alist;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.DAL
{
    public class AllocateClassRoomGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public int SaveAllocateClassRoom(AllocateClassroom allocate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query =
                "INSERT INTO t_allocateclassroom (DepartmentId,CourseId,RoomId,DayId,FromTime,ToTime,Status) VALUES ('" +
                allocate.DepartmentId + "','" + allocate.CourseId + "','" + allocate.RoomId + "','" + allocate.DayId +
                "','" + allocate.From + "','" + allocate.To + "','1')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        //public List<AllocateClassroom> GetAllRoomAllocation()
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "SELECT * FROM t_allocateclassroom WHERE Status='1'";
        //    SqlCommand command=new SqlCommand(query,connection);
        //    List<AllocateClassroom>list=new List<AllocateClassroom>();
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            AllocateClassroom allocate=new AllocateClassroom();
        //            allocate.DayId = Convert.ToInt32(reader["DayId"].ToString());
        //            allocate.RoomId = Convert.ToInt32(reader["RoomId"].ToString());
        //            allocate.From = Convert.ToDateTime(reader["FromTime"].ToString());
        //            allocate.To = Convert.ToDateTime(reader["ToTime"].ToString());
        //            list.Add(allocate);
        //        }
        //        reader.Close();
        //    }
        //    connection.Close();
        //    return list;
        //}


        public bool GetRoomCheck(AllocateClassroom allocate)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "SELECT * FROM t_allocateclassroom WHERE (Status='1') and (RoomId='" + allocate.RoomId + "' and DayId= '" + allocate.DayId + "') and ((ToTime>'"+allocate.From+"' AND FromTime<'"+allocate.To+"'))";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
                
            }
            connection.Close();
            return false;
        }

    }
}
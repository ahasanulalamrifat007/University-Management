using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemMVC.Models.ViewModels;

namespace UniversityManagementSystemMVC.DAL
{
    public class ViewAllocateClassRoomGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public List<ViewAllocateClassRoom> GetAllViewAllocatedClassRoom(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * From schedule WHERE DepartmentId='" + departmentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            List<ViewAllocateClassRoom> aViewAllocatedClassRooms = new List<ViewAllocateClassRoom>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ViewAllocateClassRoom viewAllocateClassroom = new ViewAllocateClassRoom();
                viewAllocateClassroom.DepartmentId = (int)reader["DepartmentId"];
                viewAllocateClassroom.CourseCode = reader["CourseCode"].ToString();
                viewAllocateClassroom.CourseName = reader["CourseName"].ToString();
                viewAllocateClassroom.RoomNo = reader["RoomNo"].ToString();
                viewAllocateClassroom.Day = reader["Day"].ToString();
                //viewAllocateClassroom.FromTime = reader["FromTime"].ToString();
                //viewAllocateClassroom.ToTime = reader["ToTime"].ToString();
                viewAllocateClassroom.Status = reader["Status"].ToString();

                string strtime;
                string endtime;

                if (reader["FromTime"] == DBNull.Value)
                {
                    strtime = "";
                }
                else
                {
                    string time = reader["FromTime"].ToString();
                    DateTime sDTime = DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture);
                    strtime = sDTime.ToShortTimeString();
                }

                if (reader["ToTime"] == DBNull.Value)
                {
                    endtime = "";
                }
                else
                {
                    string time = reader["ToTime"].ToString();
                    DateTime eTime = DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture);
                    endtime = eTime.ToShortTimeString();
                }
                viewAllocateClassroom.FromTime = strtime;
                viewAllocateClassroom.ToTime = endtime;

                aViewAllocatedClassRooms.Add(viewAllocateClassroom);
            }
            reader.Close();
            connection.Close();
            return aViewAllocatedClassRooms;


        }
    }
}
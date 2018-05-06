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
    public class TeacherGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["University System"].ConnectionString;

        public int SaveTeacher(Teacher aTeacher)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "INSERT INTO t_teacher (Name,Address,Email,ContactNo,DesignationId,DepartmentId,CreditTobeTaken,RemainingCredit) " +
                           "VALUES (@Name,@Address,@Email,@ContactNo,@DesignationId,@DepartmentId,@CreditTobeTaken,@RemainingCredit) ";
            SqlCommand command=new SqlCommand(query,connection);

            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = aTeacher.Name;
            command.Parameters.Add("@Address", SqlDbType.VarChar);
            command.Parameters["@Address"].Value = aTeacher.Address;
            command.Parameters.Add("@Email", SqlDbType.VarChar);
            command.Parameters["@Email"].Value = aTeacher.Email;
            command.Parameters.Add("@ContactNo", SqlDbType.VarChar);
            command.Parameters["@ContactNo"].Value = aTeacher.ContactNo;
            command.Parameters.Add("@DesignationId", SqlDbType.Int);
            command.Parameters["@DesignationId"].Value = aTeacher.DesignationId;
            command.Parameters.Add("@DepartmentId", SqlDbType.Int);
            command.Parameters["@DepartmentId"].Value = aTeacher.DepartmentId;
            command.Parameters.Add("@CreditTobeTaken", SqlDbType.Float);
            command.Parameters["@CreditTobeTaken"].Value = aTeacher.CreditTobeTaken;
            command.Parameters.Add("@RemainingCredit", SqlDbType.Float);
            command.Parameters["@RemainingCredit"].Value = aTeacher.CreditTobeTaken;

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            query = "INSERT INTO t_Users (Username,Password,Role) VALUES(@Username, @Password, @Role)";
            command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("@Username", SqlDbType.VarChar);
            command.Parameters["@Username"].Value = aTeacher.Name.ToLower()+"@"+aTeacher.ContactNo;
            command.Parameters.Add("@Password", SqlDbType.VarChar);
            command.Parameters["@Password"].Value = "12345";
            command.Parameters.Add("@Role", SqlDbType.VarChar);
            if (aTeacher.DesignationId == 2)
            {
                command.Parameters["@Role"].Value = "Admin";
            }
            else
            {
                command.Parameters["@Role"].Value = "User";
            }
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected;
        }
        public List<Teacher> GetAllTeachers()
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "SELECT * FROM t_teacher";
            SqlCommand command=new SqlCommand(query,connection);
            List<Teacher> aList=new List<Teacher>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Teacher aTeacher=new Teacher();
                    aTeacher.Id = Convert.ToInt32(reader["Id"].ToString());
                    aTeacher.Name = reader["Name"].ToString();
                    aTeacher.Address = reader["Address"].ToString();
                    aTeacher.Email = reader["Email"].ToString();
                    aTeacher.ContactNo = reader["ContactNo"].ToString();
                    aTeacher.DesignationId = Convert.ToInt32(reader["DesignationId"].ToString());
                    aTeacher.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                    aTeacher.CreditTobeTaken = Convert.ToDouble(reader["CreditTobeTaken"].ToString());
                    aTeacher.RemainingCredit = Convert.ToDouble(reader["RemainingCredit"].ToString());
                    aList.Add(aTeacher);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }

        public void updatecredit( double credit,int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Update t_teacher SET RemainingCredit='" + credit + "' WHERE Id='" + id + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            }

    }
}
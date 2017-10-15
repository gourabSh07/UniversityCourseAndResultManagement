using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.DLL
{
    public class TeacherGateway
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;

        public int SaveTeacher(Teacher teacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string querry = "INSERT INTO Teacher VALUES('" + teacher.Name + "','" + teacher.Address + "','" +
                            teacher.Email + "','" + teacher.ContactNo + "','" + teacher.Designation + "','" +
                            teacher.DepartmentId + "','" + teacher.CreditToBeTaken + "')";
            SqlCommand command = new SqlCommand(querry, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public string FindDuplicatEmail(string email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Teacher WHERE Email='" + email + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            string message = null;
            connection.Open();

            if (reader.HasRows)
            {
                message = "Email Already Exist.";
            }
            reader.Close();
            connection.Close();
            return message;
        }

        public List<Teacher> GetAllTeacher()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<Teacher> teachers = new List<Teacher>();
            string query = "SELECT * FROM Teacher";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Teacher teacher = new Teacher
                {
                    Id = (int)(reader["Id"]),
                    DepartmentId = (int)reader["DepartmentId"],
                    Name = reader["Name"].ToString(),
                    CreditToBeTaken = (decimal)reader["CreditToBeTaken"]
                };
                teachers.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return teachers;

        }
    }
}
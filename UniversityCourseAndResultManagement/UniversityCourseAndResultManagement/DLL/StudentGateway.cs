using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.DLL
{
    public class StudentGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;
        public int SaveStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Student VALUES('" + student.Name + "','" + student.Email + "','" + student.ContactNo + "','" +
                   student.Date + "','" + student.Address + "'," + student.DepartmentId + ",'" + student.RegNo + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public string FindDuplicatEmail(string email)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Student WHERE Email='" + email + "' ";
            SqlCommand command = new SqlCommand(query, connection);

            string message = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                message = "Email Already Exist.";
            }
            reader.Close();
            connection.Close();
            return message;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Student";
            SqlCommand command = new SqlCommand(query, connection);

            List<Student> students = new List<Student>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student aStudent = new Student
                {
                    Id = (int)reader["Id"],
                    RegNo = reader["RegNo"].ToString(),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Address = reader["Address"].ToString(),
                    ContactNo = reader["ContactNo"].ToString(),
                    Date = Convert.ToDateTime(reader["Date"].ToString()),
                    DepartmentId = (int)reader["DepartmentId"]
                };
                students.Add(aStudent);
            }
            reader.Close();
            connection.Close();
            return students;
        }

        public string GetLastAddedStudentRegistration(string searchKey)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Student st WHERE RegNo LIKE '%" + searchKey + "%' and Id=(select Max(Id) FROM Student st WHERE RegNo LIKE '%" + searchKey + "%' )";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            Student aStudent = null;
            string regNo = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                aStudent = new Student
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    RegNo = reader["RegNo"].ToString(),
                    Email = reader["Email"].ToString(),
                    ContactNo = reader["ContactNo"].ToString(),

                };
                regNo = aStudent.RegNo;
            }

            connection.Close();
            command.Dispose();
            reader.Close();
            return regNo;
        }
    }
}
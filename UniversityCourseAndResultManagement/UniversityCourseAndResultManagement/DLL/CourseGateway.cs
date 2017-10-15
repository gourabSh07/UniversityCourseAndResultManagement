using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.DLL
{
    public class CourseGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;
        public int SaveCourse(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Course VALUES('" + course.Code + "','" + course.Name + "'," + course.Credit + ",'" +
                   course.Description + "'," + course.DepartmentId + ",'" + course.Semester + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public string FindDuplicateCode(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Course WHERE Code='" + course.Code + "'";
            SqlCommand command = new SqlCommand(query, connection);
            string message = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                message = "Course Code Already Exist.";
            }
            reader.Close();
            connection.Close();
            return message;
        }
        public string FindDuplicateName(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Course WHERE Name='" + course.Name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            string message = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                message = "Course Name Already Exist.";
            }
            reader.Close();
            connection.Close();
            return message;
        }
        public List<Course> GetAllCourses()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<Course> courses = new List<Course>();
            string query = "SELECT * FROM Course";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Course course = new Course
                {
                    Id = (int)(reader["Id"]),
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString(),
                    Credit = Convert.ToDecimal(reader["Credit"]),
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"])
                };
                courses.Add(course);
            }

            reader.Close();
            connection.Close();
            return courses;
        }
    }
}
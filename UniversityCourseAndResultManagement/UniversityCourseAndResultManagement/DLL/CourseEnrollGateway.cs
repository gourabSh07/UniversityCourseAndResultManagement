using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Antlr.Runtime.Misc;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.DLL
{
    public class CourseEnrollGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;

        public List<ViewStudentDetails> GetAllStudentDetails(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<ViewStudentDetails> viewStudentDetailses = new ListStack<ViewStudentDetails>();
            string query = "SELECT * FROM ViewStudentDetails where StudentId='" + studentId + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                ViewStudentDetails aViewStudentDetails = new ViewStudentDetails
                {
                    Id = Convert.ToInt32(reader["StudentId"]),
                    Name = reader["StudentName"].ToString(),
                    Email = reader["StudentEmail"].ToString(),
                    RegNo = reader["StudentRegNo"].ToString(),
                    DepartmentName = reader["DepartmentName"].ToString()
                };
                viewStudentDetailses.Add(aViewStudentDetails);
            }
            reader.Close();
            connection.Close();
            return viewStudentDetailses;
        }
        public List<ViewCourseFromStudentDepartmentName> GetAllCourseFromStudentDepartmentNames(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            List<ViewCourseFromStudentDepartmentName> viewCourseFromStudentDepartment = new List<ViewCourseFromStudentDepartmentName>();
            string query = "SELECT * FROM ViewCourseFromStudentDepartmentMenu where StudentId='" + studentId + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ViewCourseFromStudentDepartmentName aViewStudentDepartmentName = new ViewCourseFromStudentDepartmentName();
                aViewStudentDepartmentName.CourseId = Convert.ToInt32(reader["CourseId"]);
                aViewStudentDepartmentName.CourseName = reader["CourseName"].ToString();
                aViewStudentDepartmentName.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                aViewStudentDepartmentName.StudentId = Convert.ToInt32(reader["StudentId"]);
                aViewStudentDepartmentName.StudentDepartmentId = Convert.ToInt32(reader["StudentDepartmentId"]);
                viewCourseFromStudentDepartment.Add(aViewStudentDepartmentName);
            }

            reader.Close();
            connection.Close();
            return viewCourseFromStudentDepartment;
        }


        public int EnrollCourse(CourseEnroll courseEnroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO EnrollCourse VALUES('" + courseEnroll.StudentId + "','" + courseEnroll.CourseId + "','" + courseEnroll.EnrollDate + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }


        public string FindSameCourseForAStudent(CourseEnroll courseEnroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM EnrollCourse WHERE StudentId='" + courseEnroll.StudentId + "' AND CourseId='" + courseEnroll.CourseId + "'";
            SqlCommand command = new SqlCommand(query, connection);

            string message = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                message = "This Course Already Enroll by This Student";
            }
            reader.Close();
            connection.Close();
            return message;
        }
    }
}
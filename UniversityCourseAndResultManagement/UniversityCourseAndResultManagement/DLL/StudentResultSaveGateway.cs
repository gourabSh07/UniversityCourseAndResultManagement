using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.DLL
{
    public class StudentResultSaveGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;

        public List<ViewEnrollCourseByAStudentId> GetAllEnrollCourseFromStudentId(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM viewEnrollCourseByStudentId where StudentId='" + studentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewEnrollCourseByAStudentId> viewEnrollCourseByAStudentIds = new List<ViewEnrollCourseByAStudentId>();

            while (reader.Read())
            {
                ViewEnrollCourseByAStudentId aViewEnrollCourseByAStudentId = new ViewEnrollCourseByAStudentId
                {
                    CourseId = Convert.ToInt32(reader["CourseId"]),
                    CourseName = reader["CourseName"].ToString(),
                    EnrollStudentId = Convert.ToInt32(reader["EnrollStudentId"]),
                    EnrollCourseId = Convert.ToInt32(reader["EnrollCourseId"]),
                    StudentId = Convert.ToInt32(reader["StudentId"])
                };

                viewEnrollCourseByAStudentIds.Add(aViewEnrollCourseByAStudentId);
            }
            reader.Close();
            connection.Close();
            return viewEnrollCourseByAStudentIds;
        }
        public int SaveStudentResult(StudentResultSaveModel studentResultSaveModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO StudentResult VALUES('" + studentResultSaveModel.StudentId + "','" + studentResultSaveModel.CourseId + "','" + studentResultSaveModel.Grade + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }


        public string FindSameCourseForAStudentWhichAssignAGrade(StudentResultSaveModel studentResultSaveModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM StudentResult WHERE StudentId='" + studentResultSaveModel.StudentId + "' AND CourseId='" + studentResultSaveModel.CourseId + "'";
            SqlCommand command = new SqlCommand(query, connection);

            string message = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                message = "Grade Already assign for this Course by this Student";
            }
            reader.Close();
            connection.Close();
            return message;
        }
    }
}
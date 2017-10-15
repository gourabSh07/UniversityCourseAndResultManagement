using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.DLL
{
    public class AssingCourseViewGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;

        public decimal GetTakenCredit(int dId, int tId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            decimal takenCredit = 0;
            string query = "SELECT * FROM CourseAssigneView WHERE DepartmentId=" + dId + " AND TeacherId=" + tId + "";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                takenCredit += Convert.ToDecimal(reader["CourseCerdit"]);
            }
            connection.Close();
            reader.Close();
            return takenCredit;
        }
        public List<CourseAssingModel> CourseInformation(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<CourseAssingModel> remainingCredits = new List<CourseAssingModel>();
            string query = "SELECT * FROM CourseAssigneView WHERE CourseDepartment=" + departmentId + "";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CourseAssingModel courseAssingModel = new CourseAssingModel
                {
                    CourseCode = reader["CourseCode"].ToString(),
                    CourseName = reader["CourseName"].ToString(),
                    CourseSemester = reader["CourseSemester"].ToString(),
                    TeacherName = reader["TeacherName"].ToString()
                };


                remainingCredits.Add(courseAssingModel);
            }
            reader.Close();
            connection.Close();
            return remainingCredits;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.DLL
{
    public class ViewResultGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;
        public List<ResultView> GetAllCourseCodeNameResultByStudentId(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            List<ResultView> codeNameGradeList = new List<ResultView>();
            string query = "SELECT * FROM viewCodeNameGradeFromStudentId WHERE StudentId=" + studentId + " ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ResultView resultView = new ResultView
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    CourseCode = reader["CourseCode"].ToString(),
                    CourseName = reader["CourseName"].ToString(),
                    Grade = reader["Grade"].ToString(),
                };

                codeNameGradeList.Add(resultView);
            }
            reader.Close();
            connection.Close();
            return codeNameGradeList;
        }

    }
}
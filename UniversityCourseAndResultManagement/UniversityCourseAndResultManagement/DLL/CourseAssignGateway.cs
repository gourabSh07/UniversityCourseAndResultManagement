using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityCourseAndResultManagement.DLL
{

    public class CourseAssignGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;

        public int Save(int d, int t, int c)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO CourseAssign VALUES('" + d + "','" + t + "'," + c + ")";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }
        public bool OverlapCourse(int tid, int cid)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM CourseAssign WHERE TeacherId=" + tid + " AND CourseId=" + cid + "";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }

            reader.Close();
            connection.Close();
            return false;
        }
        public bool AssignCourse(int cid)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM CourseAssign WHERE CourseId =" + cid + "";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }

            reader.Close();
            connection.Close();
            return false;
        }

    }
}
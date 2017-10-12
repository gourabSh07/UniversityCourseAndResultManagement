using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.DLL
{
    public class DepartmentGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;

        public int SaveDepartment(Department department)
        {
            int rowAffected;
            string querry = "INSERT INTO Department VALUES('" + department.Code + "','" + department.Name + "')";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(querry, connection);
            connection.Open();
            rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public string FindDuplicateCode(Department department)
        {
            string message = null;
            string querry = "SELECT * FROM Department WHERE Code='" + department.Code + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(querry, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                message = "Department Code  Already Exist.";
            }
            reader.Close();
            connection.Close();
            return message;
        }

        public string FindDuplicateName(Department department)
        {
            string message = null;
            string querry = "SELECT * FROM Department WHERE Name='" + department.Name + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(querry, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                message = "Department Name Already Exits";
            }
            reader.Close();
            connection.Close();
            return message;
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            string querry = "SELECT * FROM Department";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(querry, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var department = new Department
                {
                    ID = (int)reader["Id"],
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString()

                };
                departments.Add(department);
            }
            reader.Close();
            connection.Close();
            return departments;
        }
    }
}
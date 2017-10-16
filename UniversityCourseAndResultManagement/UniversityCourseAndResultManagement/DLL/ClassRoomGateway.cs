using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.DLL
{
    public class ClassRoomGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityMSDB"].ConnectionString;
        public int SaveAllocateClassRoom(AllocateClassRoom allocate)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO AllocateClassRoom(DepartmentId,CourseId,RoomNo,DayN,StrartFrom,EndTo) VALUES (" + allocate.DepartmentId + "," + allocate.CourseId + ",'" + allocate.RoomNo + "','" + allocate.Day + "','" + allocate.From + "','" + allocate.To + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<ClassSheduleIntoModel> GetAllClassSheduleIntoList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM ScheduleInfoView";
            SqlCommand command = new SqlCommand(query, connection);

            List<ClassSheduleIntoModel> sheduleIntoList = new List<ClassSheduleIntoModel>();


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ClassSheduleIntoModel classSheduleIntoModel = new ClassSheduleIntoModel
                {
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                    CourseId = Convert.ToInt32(reader["Id"]),
                    CourseCode = reader["Code"].ToString(),
                    CourseName = reader["Name"].ToString(),
                    SheduleInfo = reader["ScheduleInfo"].ToString(),
                };
                sheduleIntoList.Add(classSheduleIntoModel);
            }
            reader.Close();
            connection.Close();
            return sheduleIntoList;
        }

    }
}
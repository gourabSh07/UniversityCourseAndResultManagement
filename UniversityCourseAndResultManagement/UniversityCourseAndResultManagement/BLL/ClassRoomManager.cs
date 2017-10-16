using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class ClassRoomManager
    {
        ClassRoomGateway classRoomGateway = new ClassRoomGateway();
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();

        public List<Department> GetAllDepartments()
        {
            return departmentManager.GetAllDepartments();
        }

        public List<Course> GetAllCourses()
        {
            return courseManager.GetAllCourses();
        }

        public string SaveAllocatedClassRoom(AllocateClassRoom allocateClassRoom)
        {
            if (classRoomGateway.SaveAllocateClassRoom(allocateClassRoom) > 0)
            {
                return "Save Successfully";
            }
            return "Failed To Save";
        }

        public List<ClassSheduleIntoModel> GetAllClassSheduleIntoList()
        {
            return classRoomGateway.GetAllClassSheduleIntoList();
        }
    }
}
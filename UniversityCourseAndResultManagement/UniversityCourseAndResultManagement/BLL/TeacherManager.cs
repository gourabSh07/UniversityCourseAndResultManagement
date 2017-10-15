using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class TeacherManager
    {
        DepartmentManager departmentManager = new DepartmentManager();
        TeacherGateway teacherGateway = new TeacherGateway();
        CourseManager courseManager = new CourseManager();
        AssingCourseViewManager assingCourseViewManager = new AssingCourseViewManager();

        public List<Department> GetAllDepartments()
        {
            return departmentManager.GetAllDepartments();
        }

        public string SaveTeacher(Teacher teacher)
        {
            if (teacherGateway.FindDuplicatEmail(teacher.Email) == null)
            {
                if (teacherGateway.SaveTeacher(teacher) > 0)
                {
                    return "Successfully Saved";
                }
                else
                {
                    return "Failed To Save";
                }
            }
            else
            {
                return teacherGateway.FindDuplicatEmail(teacher.Email);
            }
        }
        public List<Teacher> GetAllTeachers()
        {
            return teacherGateway.GetAllTeacher();
        }
        public List<Course> GetAllCourses()
        {
            return courseManager.GetAllCourses();
        }
        public decimal GetTakenCredit(int dId, int tId)
        {
            return assingCourseViewManager.GetTakenCredit(dId, tId);
        }

    }
}
using System.Collections.Generic;
using System.Linq;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class CourseAssignToTeacherManager
    {
        CourseAssignToTeacherGateway courseAssignToTeacherGateway = new CourseAssignToTeacherGateway();
        public string Save(CourseAssignToTeacher courseAssign)
        {

            CourseAssignToTeacher courseAssignTo = GetAll.ToList().Find(ca => ca.CourseId == courseAssign.CourseId && ca.Status);

            if (courseAssignTo == null)
            {
                if (courseAssignToTeacherGateway.Insert(courseAssign) > 0)
                {
                    return "Assigned successfully";
                }
                return "Failed to save";
            }

            return "Overlaping not allowed!";
        }


        public IEnumerable<CourseAssignToTeacher> GetAll
        {
            get { return courseAssignToTeacherGateway.GetAll; }
        }

    }
}
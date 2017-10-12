using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class CourseAssingModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public decimal CourseCredit { get; set; }
        public string CourseSemester { get; set; }
    }
}
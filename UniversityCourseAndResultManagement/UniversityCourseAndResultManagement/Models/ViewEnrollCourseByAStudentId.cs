using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class ViewEnrollCourseByAStudentId
    {
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public int EnrollStudentId { set; get; }
        public int EnrollCourseId { set; get; }
        public int StudentId { set; get; }
    }
}
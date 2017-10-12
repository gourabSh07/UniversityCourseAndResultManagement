using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class ResultView
    {

        public int Id { set; get; }
        [Required(ErrorMessage = "Student Reg. No. Must be select")]
        [DisplayName("Student Reg. No.")]
        public int StudentId { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Department { set; get; }
        public string CourseCode { set; get; }
        public string CourseName { set; get; }
        public string Grade { set; get; }
    }
}
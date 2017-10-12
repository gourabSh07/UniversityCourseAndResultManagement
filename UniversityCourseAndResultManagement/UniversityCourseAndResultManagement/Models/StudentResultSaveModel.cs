using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class StudentResultSaveModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Student Reg. No. Must be select")]
        [DisplayName("Student Reg. No.")]
        public int StudentId { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Department { set; get; }

        [Required(ErrorMessage = "Course Must be Select")]
        [DisplayName("Select Course")]
        public int CourseId { set; get; }
        [Required(ErrorMessage = "Select Grade Letter")]
        [DisplayName("Select Grade Letter")]
        public string Grade { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Course Code")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Course Code Must be at least 5 Character Long")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Enter Course Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Course Credit")]
        [Range(0.5, 5.0, ErrorMessage = "Credit Range 0.5 to 5.0")]
        public decimal Credit { get; set; }
        [Required(ErrorMessage = "Enter Course Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Select a Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Select a Semester")]
        [DisplayName("Semester")]
        public string Semester { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class AllocateClassRoom
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Select Room No")]

        public string RoomNo { get; set; }
        [Required(ErrorMessage = "Please Select Day")]

        public string Day { get; set; }
        [Required(ErrorMessage = "Please Enter course start time in From Field")]

        public TimeSpan From { get; set; }
        [Required(ErrorMessage = "PPlease Enter course finished time in From Field")]

        public TimeSpan To { get; set; }
    }
}
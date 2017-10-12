using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter a Teacher Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Teacher Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Teacher Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Teacher Contact Number")]
        [DisplayName("Contact No")]
        public int ContactNo { get; set; }
        [Required(ErrorMessage = "Enter Teacher decsignation")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Enter Teacher Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Enter Teacher Total Cerdit")]
        [Range(0, int.MaxValue, ErrorMessage = "Total Cerdit must be a positive number")]
        [DisplayName("Cedit To Be Taken")]
        public decimal CreditToBeTaken { get; set; }
    }
}
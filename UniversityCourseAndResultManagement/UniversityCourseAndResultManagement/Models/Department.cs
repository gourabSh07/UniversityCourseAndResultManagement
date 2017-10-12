using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class Department
    {
        public Nullable<int> ID { get; set; }

        [Required(ErrorMessage = "Please Enter A Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must be between 2 to 7 characters")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Enter A Department Name")]
        public string Name { get; set; }

        public Department(int? id, string code, string name)
        {
            ID = id;
            Code = code;
            Name = name;
        }

        public Department()
        {

        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace UniversityCourseAndResultManagement.Models
{

    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Department code!")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must be contains between 2 and 7 characters!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a valid Department name!")]

        public string Name { get; set; }
    }
}
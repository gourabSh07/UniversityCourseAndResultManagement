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

        public int DepartmentId { get; set; }
        public int CourseId { get; set; }

        public string RoomNo { get; set; }

        public string Day { get; set; }

        public TimeSpan From { get; set; }

        public TimeSpan To { get; set; }
    }
}
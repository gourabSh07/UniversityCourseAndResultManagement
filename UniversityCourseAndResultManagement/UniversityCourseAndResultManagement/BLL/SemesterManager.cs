using System.Collections.Generic;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class SemesterManager
    {
        SemesterGateway semesterGateway = new SemesterGateway();
        public List<Semester> GetAll
        {
            get { return semesterGateway.GetAll; }
        }
    }
}
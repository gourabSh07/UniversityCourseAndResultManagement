using System.Collections.Generic;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class DesignationManager
    {
        DesignationGateway designationGateway = new DesignationGateway();
        public IEnumerable<Designation> GetAll
        {

            get { return designationGateway.GetAll; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class AssingCourseViewManager
    {
        AssingCourseViewGateway assingCourseViewGateway = new AssingCourseViewGateway();

        public decimal GetTakenCredit(int dId, int tId)
        {
            return assingCourseViewGateway.GetTakenCredit(dId, tId);
        }
        public List<CourseAssingModel> CourseInformation(int departmentId)
        {
            return assingCourseViewGateway.CourseInformation(departmentId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class ViewResultManager
    {
        ViewResultGateway resultGateway = new ViewResultGateway();
        public List<ResultView> GetAllCourseCodeNameResultByStudentId(int studentId)
        {
            return resultGateway.GetAllCourseCodeNameResultByStudentId(studentId);
        }
    }
}
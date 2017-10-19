using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class StudentResultSaveManager
    {
        StudentResultSaveGateway studentResultSaveGateway = new StudentResultSaveGateway();

        public List<ViewEnrollCourseByAStudentId> GetAllEnrollCourseFromStudentId(int studentId)
        {
            return studentResultSaveGateway.GetAllEnrollCourseFromStudentId(studentId);
        }



        public string SaveStudentResult(StudentResultSaveModel studentResultSaveModel)
        {
            if (studentResultSaveGateway.FindSameCourseForAStudentWhichAssignAGrade(studentResultSaveModel) == null)
            {

                if (studentResultSaveGateway.SaveStudentResult(studentResultSaveModel) > 0)
                {
                    return "Save Student Result Successfully.";
                }
                else
                {
                    return "Sorry! Student Result not Save";
                }

            }

            else
            {
                return studentResultSaveGateway.FindSameCourseForAStudentWhichAssignAGrade(studentResultSaveModel);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public CourseManager courseManager = new CourseManager();
        public ActionResult Save()
        {
            ViewBag.listOfSemester = GetAllSemester();
            ViewBag.listOfDepartments = courseManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            ViewBag.message = courseManager.SaveCourse(course);
            ViewBag.listOfSemester = GetAllSemester();
            ViewBag.listOfDepartments = courseManager.GetAllDepartments();
            ModelState.Clear();
            return View();
        }


        private List<SelectListItem> GetAllSemester()
        {
            List<SelectListItem> Semester = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = "---Select---"},
                new SelectListItem {Value = "1st Semester", Text = "1st Semester"},
                new SelectListItem {Value = "2nd Semester", Text = "2nd Semester"},
                new SelectListItem {Value = "3rd Semester", Text = "3rd Semester"},
                new SelectListItem {Value = "4th Semester", Text = "4th Semester"},
                new SelectListItem {Value = "5th Semester", Text = "5th Semester"},
                new SelectListItem {Value = "6th Semester", Text = "6th Semester"},
                new SelectListItem {Value = "7th Semester", Text = "7th Semester"},
                new SelectListItem {Value = "8th Semester", Text = "8th Semester"}
            };
            return Semester;
        }



        public ActionResult ViewCourseStatics()
        {
            ViewBag.listOfDepartments = courseManager.GetAllDepartments();
            return View();
        }


        public JsonResult GetCourseByDepartmentId(int deptId)
        {

            var courseList = courseManager.CourseInformation(deptId);
            foreach (var course in courseList)
            {
                if (course.TeacherName.Length < 1)
                {
                    course.TeacherName = "Not Assigned Yet";
                }
            }
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
    }
}
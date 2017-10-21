using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class CourseViewController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        //
        // GET: /CourseView/
        public ActionResult ShowAllCourse()
        {
            IEnumerable<Department> departments = departmentManager.GetAll();
            ViewBag.Departments = departments;
            IEnumerable<CourseViewModel> courseViewModels = courseManager.GetCourseViewModels;
            return View(courseViewModels);
        }

        public JsonResult GetCourseInformationByDepartmentId(int departmentId)
        {
            IEnumerable<CourseViewModel> courseViewModels = courseManager.GetCourseViewModels.ToList().FindAll(deptId => deptId.DepartmentId == departmentId);
            return Json(courseViewModels, JsonRequestBehavior.AllowGet);


        }
    }
}
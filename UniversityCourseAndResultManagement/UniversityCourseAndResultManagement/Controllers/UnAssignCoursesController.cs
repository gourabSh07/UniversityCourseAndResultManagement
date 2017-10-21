using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.BLL;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class UnAssignCoursesController : Controller
    {
        CourseManager courseManager = new CourseManager();
        //
        // GET: /UnAssignCourses/
        [HttpGet]
        public ActionResult UnAssign()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAssign(int? id)
        {
            ViewBag.Message = courseManager.UnAssignCourses();
            return View();
        }
    }
}
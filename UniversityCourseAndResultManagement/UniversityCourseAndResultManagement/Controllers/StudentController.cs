using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private string message;
        StudentManager studentManager = new StudentManager();
        public ActionResult Register()
        {
            ViewBag.listOfDepartments = studentManager.GetAllDepartments();
            return View();
        }
        [HttpPost]

        public ActionResult Register(Student student)
        {
            message = studentManager.SaveStudent(student);
            ViewBag.listOfDepartments = studentManager.GetAllDepartments();
            ViewBag.Message = message;
            ModelState.Clear();
            return View();
        }
    }
}
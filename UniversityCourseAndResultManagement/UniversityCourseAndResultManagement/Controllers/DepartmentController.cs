using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DepartmentManager departmentManager = new DepartmentManager();

        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Department department)
        {
            ViewBag.message = departmentManager.SaveDepartment(department);
            return View();
        }

        public ActionResult ViewAllDepartment()
        {
            ViewBag.DepartmentList = departmentManager.GetAllDepartments();
            return View();

        }
    }
}